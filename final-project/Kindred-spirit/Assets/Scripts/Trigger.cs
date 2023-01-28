using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    // Event to trigger
    public UnityEvent triggerEvent;

    // Tigger event on enter
    private void OnTriggerEnter(Collider other)
    {
        triggerEvent.Invoke();
    }
}
