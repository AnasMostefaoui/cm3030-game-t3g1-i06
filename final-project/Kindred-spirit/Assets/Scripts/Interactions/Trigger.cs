using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    // Event to trigger
    public UnityEvent triggerEvent;
    private bool isColliding;
    // Tigger event on enter
    private void OnTriggerEnter(Collider other)
    {
        if (isColliding) return;
        isColliding = true;

        triggerEvent.Invoke();
    }

    private void Update()
    {
        isColliding = false;
    }
}
