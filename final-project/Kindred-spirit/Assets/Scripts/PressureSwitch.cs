using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressureSwitch : MonoBehaviour
{
    // Event to cal
    public UnityEvent switchTriggered;

    private void OnCollisionEnter(Collision collision)
    {
        // Call the event when collider enters
        switchTriggered.Invoke();
    }
}
