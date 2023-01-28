using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WallSwitch : MonoBehaviour
{
    public UnityEvent wallSwitchOn;
    public UnityEvent wallSwitchOff;
    private bool isSwitched = false;

    [SerializeField]
    private bool isToggleSwitch = false;

    // Hels handling the trigger
    private bool isWithinRange = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isWithinRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isWithinRange = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isWithinRange)
        {
            if (!isSwitched)
            {
                wallSwitchOn.Invoke();
                isSwitched = true;
            } else {
                if (isToggleSwitch)
                {
                    wallSwitchOff.Invoke();
                    isSwitched = false;
                }
            }
        }
    }
}
