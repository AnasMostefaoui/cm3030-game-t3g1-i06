using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressureSwitch : MonoBehaviour
{
    // Event to cal
    public UnityEvent switchTriggered;

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Hi");
        // Call the event when collider enters
        switchTriggered.Invoke();
    }
}
