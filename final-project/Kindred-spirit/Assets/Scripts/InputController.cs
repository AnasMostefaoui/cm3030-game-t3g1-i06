using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputController : MonoBehaviour
{
    // Events to be called
    public UnityEvent onGhostSelectEvent;
    public UnityEvent onPlayerSelectEvent;
    public UnityEvent onPause;
    public UnityEvent onUnPause;

    // Check for a key press and invoke relevent event
    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && GameManager.Instance.isGhostSelected == true)
        {
            onPlayerSelectEvent.Invoke();
            GameManager.Instance.isGhostSelected = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && GameManager.Instance.isGhostSelected == false)
        {
            onGhostSelectEvent.Invoke();
            GameManager.Instance.isGhostSelected  = true;
        }

        // Press Escape key for pause menu
        if (Input.GetKeyDown(KeyCode.Escape) && GameManager.Instance.isPaused == false)
        {
            Debug.Log("escape 1");
            onPause.Invoke();            
            GameManager.Instance.TogglePause();
        } else if (Input.GetKeyDown(KeyCode.Escape) && GameManager.Instance.isPaused == true)
        {
            Debug.Log("escape 2");
            onUnPause.Invoke();
            GameManager.Instance.TogglePause();
        }
    }
}
