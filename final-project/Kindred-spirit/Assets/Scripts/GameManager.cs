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

    // Starting spirit health
    public float spiritHealth = 100f;
    // Keep track of spirit link being active
    public bool spiritlinkActive = false;
    // activate or deactivate spirit link
    public UnityEvent toggleSpiritLink;

    // True if the player has selected the Ghost
    public bool isGhostSelected = false;

    // True if game is paused
    public bool isPaused = false;

    // Game Over if no spirit link
    public UnityEvent gameOver;

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

    private void Update()
    {
        // Game over if spirt health runs out
        if(spiritHealth <= 0)
        {
            gameOver.Invoke();
            Time.timeScale = 0f;
        }
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

    // Turns the spirit link on or off
    public void ToggleSpiritLink()
    {
        Debug.Log("ToggleSpiritLink");
        if (spiritlinkActive){
            spiritlinkActive = false;
            toggleSpiritLink.Invoke();
        } else {
            spiritlinkActive = true;
            toggleSpiritLink.Invoke();
        }
    }
}
