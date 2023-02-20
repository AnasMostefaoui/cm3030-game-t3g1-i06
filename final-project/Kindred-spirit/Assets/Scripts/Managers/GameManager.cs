using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // instance for GameManager singleton
    private static GameManager instance;

    // Allow public access to GameManage singleton instance
    public static GameManager Instance { get { return instance; } }

    // Game Over delegate
    public delegate void OnGameOver();

    public static event OnGameOver onGameOver;

    // Get Managers
    public SpiritManager spiritManager;
    public UIManager uiManager;
    public SoundManager soundManager;

    // True if game is paused
    public bool isPaused = false;

    // True if game is over
    public bool isGameOver
    {
        get => _isGameOver;
        set
        {
            _isGameOver = value;
            if(_isGameOver)
            {
                onGameOver?.Invoke();
            }
        }
    }


    // Reference to both Characters
    private GameObject humanCharacter;
    private GameObject ghostCharacter;
    private GameObject currentPlayer;
    private bool _isGameOver = false;

    // Main camera for switching
    private Camera mainCamera;

    // Use onAwake to setup GameManager singleton
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        // Find characters
        humanCharacter = GameObject.FindGameObjectWithTag("Player");
        ghostCharacter = GameObject.FindGameObjectWithTag("GhostPlayer");
        mainCamera = Camera.main;
        currentPlayer = humanCharacter;
        DisablePlayerControl(ghostCharacter);
        onGameOver += handleGameOver;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnDestroy()
    {
        var subscribers = onGameOver.GetInvocationList();

        for (int i = 0; i < subscribers.Length; i++)
        {
            onGameOver -= subscribers[i] as OnGameOver;
        }
    }

    private void handleGameOver()
    {
        isPaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        humanCharacter.SetActive(false);
        ghostCharacter.SetActive(false);
    }

    // Pauses and Unpauses the game using timescale
    public void TogglePause()
    {
        Debug.Log("Pause has been toggled to: " + isPaused);
        if (!isPaused)
        {
            Time.timeScale = 0;
            isPaused = true;
        } else {
            Time.timeScale = 1;
            isPaused = false;
        }
    }

    private void DisablePlayerControl(GameObject player)
    {
        player.GetComponent<ISelectablePlayer>().Deselect();
        player.GetComponent<Mover>().enabled = false;
        player.GetComponentInChildren<Animator>().SetBool("isRunning", false);
    }

    private void EnablePlayerControl(GameObject player)
    {
        player.GetComponent<ISelectablePlayer>().Select();
        player.GetComponent<Mover>().enabled = true;
        mainCamera.GetComponent<CameraFollow>().SetTarget(player.transform);
    }

    public void CharacterSwitch()
    {
        if(humanCharacter.GetComponent<HumanPlayer>().canSwitch == false )
        {
            return;
        }

        if (currentPlayer == ghostCharacter)
        {
            soundManager.PlayHumanSwitch();
            DisablePlayerControl(ghostCharacter);
            EnablePlayerControl(humanCharacter);
            currentPlayer = humanCharacter;
        } else if(currentPlayer == humanCharacter) {
            soundManager.PlayDogSwitch();
            DisablePlayerControl(humanCharacter);
            EnablePlayerControl(ghostCharacter);
            currentPlayer = ghostCharacter;
        }

        uiManager.refreshUI();
    }
    public void RestartLevel()
    {
        isGameOver = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }

    public GameObject GetHumanPlayer()
    {
        return humanCharacter;
    }

    public GameObject GetGhostPlayer()
    {
        return ghostCharacter;
    }

    public bool isHumanSelected => currentPlayer == humanCharacter;
    public bool isGhostSelected => currentPlayer == ghostCharacter;
}
