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

    // True if the player has selected the Ghost
    public bool isGhostSelected = false;

    // True if game is paused
    public bool isPaused = false;

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
}
