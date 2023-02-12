using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressureSwitch : MonoBehaviour
{
    // Event to call
    public UnityEvent switchTriggered;
    public UnityEvent switchTriggeredOff;

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Pressure Switch Triggered");
        // Call the event when collider enters
        switchTriggered.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Pressure Switch DeTriggered");
        // Call the event when collider enters
        switchTriggeredOff.Invoke();
    }
}
