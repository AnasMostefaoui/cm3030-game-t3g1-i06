using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum DoorState
{
    Closed,
    IsOpening,
    IsOpened
}
// Attach this script to a door object
public class Door : MonoBehaviour
{
    private float openingDistance = 15f;
    public float openingSpeed = 2f;
    private float originalY = 0;
    private DoorState doorState = DoorState.Closed;

    private void Start()
    {
        originalY = transform.position.y;
    }

    // Called when a door is opened
    public void OpenDoor()
    {
        doorState = DoorState.IsOpening;
    }

    private void Update()
    {
        if(doorState == DoorState.IsOpening)
        {
            if(transform.position.y <= originalY - openingDistance)
            {
                doorState = DoorState.IsOpened;
            } else
            {
                transform.Translate(0f,-1 *openingSpeed * Time.deltaTime, 0f, Space.World);
            } 

        }

    }
}
