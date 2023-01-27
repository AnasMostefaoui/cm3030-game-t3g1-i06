using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attach this script to a door object
public class Door : MonoBehaviour
{
    // Called when a door is opened
    public void OpenDoor()
    {
        // Sets the object to inactive making it disappear. This needs changing to create an open animation
        gameObject.SetActive(false);
    }
}
