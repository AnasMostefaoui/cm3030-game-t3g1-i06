using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    // instance for GameManager singleton
    private static GameManager instance;

    // Allow public access to GameManage singleton instance
    public static GameManager Instance { get { return instance; } }

    // Get Managers
    public SpiritManager spiritManager;
    public UIManager uiManager;

    // True if game is paused
    public bool isPaused = false;

    // Reference to both Characters
    private GameObject humanCharacter;
    private GameObject ghostCharacter;
    private GameObject currentPlayer;

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
        if (currentPlayer == ghostCharacter)
        {
            DisablePlayerControl(ghostCharacter);
            EnablePlayerControl(humanCharacter);
            currentPlayer = humanCharacter;
        } else if(currentPlayer == humanCharacter) {
            DisablePlayerControl(humanCharacter);
            EnablePlayerControl(ghostCharacter);
            currentPlayer = ghostCharacter;
        }

        uiManager.refreshUI();
    }

    public bool isHumanSelected => currentPlayer == humanCharacter;
    public bool isGhostSelected => currentPlayer == ghostCharacter;
}
