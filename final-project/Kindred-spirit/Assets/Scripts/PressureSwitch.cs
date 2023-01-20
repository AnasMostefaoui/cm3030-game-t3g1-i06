using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressureSwitch : MonoBehaviour
{
    public UnityEvent switchTriggered;

    private void OnCollisionEnter(Collision collision)
    {
        switchTriggered.Invoke();
    }
}
