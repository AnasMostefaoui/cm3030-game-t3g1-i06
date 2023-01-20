using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public float levelTimer = 60f;
    public static GameManager Instance { get { return instance; } }

    public bool isGhostSelected = false;
    public bool isPaused = false;
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
        levelTimer -= Time.deltaTime;
    }

    public void TogglePause()
    {
        Debug.Log(Time.timeScale);
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
