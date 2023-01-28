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
    // True if the player has selected the Ghost
    public bool isGhostSelected = false;

    // True if game is paused
    public bool isPaused = false;

    // Reference to both Characters
    private GameObject humanCharacter;
    private GameObject ghostCharacter;

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
    }

    private void Start()
    {
        // Find characters
        humanCharacter = GameObject.FindGameObjectWithTag("Player");
        ghostCharacter = GameObject.FindGameObjectWithTag("GhostPlayer");
        mainCamera = Camera.main;
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

    public void CharacterSwitch()
    {
        if (isGhostSelected)
        {
            // Switch to human
            isGhostSelected = false;
            ghostCharacter.GetComponent<GhostPlayer>().DeSelectGhost();
            humanCharacter.GetComponent<HumanPlayer>().SelectPlayer();
            humanCharacter.GetComponent<Mover>().enabled = true;
            ghostCharacter.GetComponent<Mover>().enabled = false;
            uiManager.TogglePlayer();
            mainCamera.GetComponent<CameraFollow>().SetTarget(humanCharacter.transform);
        } else {
            // Switch to Ghost 
            isGhostSelected = true;
            ghostCharacter.GetComponent<GhostPlayer>().SelectGhost();
            humanCharacter.GetComponent<HumanPlayer>().DeSelectPlayer();
            humanCharacter.GetComponent<Mover>().enabled = false;
            ghostCharacter.GetComponent<Mover>().enabled = true;
            uiManager.TogglePlayer();
            mainCamera.GetComponent<CameraFollow>().SetTarget(ghostCharacter.transform);            
        }
    }
}
