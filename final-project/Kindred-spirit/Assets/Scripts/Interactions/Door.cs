using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum DoorState
{
    Closed,
    IsOpening,
    IsOpened,
    IsClosing
}
// Attach this script to a door object
public class Door : MonoBehaviour
{
    public float openingDistance = 7.8f;
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

    public void CloseDoor()
    {
        doorState = DoorState.IsClosing;
        StartCoroutine(ClosingDoor());
    }

    private void Update()
    {
        if (doorState == DoorState.IsOpening)
        {
            if (transform.position.y <= originalY - openingDistance)
            {
                doorState = DoorState.IsOpened;
            }
            else
            {
                transform.Translate(0f, -1 * openingSpeed * Time.deltaTime, 0f, Space.World);
            }
        }
    }

    IEnumerator ClosingDoor()
    {
        if (doorState == DoorState.IsClosing)
        {
            if (transform.position.y >= originalY)
            {
                doorState = DoorState.Closed;
            }
            else
            { 
                transform.Translate(0f, 1 * openingSpeed * Time.deltaTime, 0f, Space.World);
            }
        }

        // Wait for the required time
        yield return new WaitForSeconds(0.001f);

        // If spirit increase remains and we are not at max health, coroutine recurs
        if (doorState == DoorState.IsClosing)
        {
            StartCoroutine(ClosingDoor());
        }
    }
}
