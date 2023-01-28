using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputController : MonoBehaviour
{
    // Events to be called
    public UnityEvent onPause;
    public UnityEvent onUnPause;

    // Check for a key press and invoke relevent event
    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameManager.Instance.CharacterSwitch();
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
