using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum CageState
{
    Closed,
    IsOpening,
    IsOpened,
    IsClosing
}

public class CageAnimation : MonoBehaviour
{
    public float openingDistance = 90f;
    public float openingSpeed = -30.0f;
    private float remainingToOpen;
    private float originalY = 0;
    private CageState cageState = CageState.Closed;
    private AudioSource cageOpenSound;

    private void Start()
    {
        remainingToOpen = openingDistance;
        originalY = transform.rotation.y;
        cageOpenSound = gameObject.GetComponent<AudioSource>();
    }

    // Called when a door is opened
    public void OpenDoor()
    {
        cageState = CageState.IsOpening;
        cageOpenSound.Play();
    }

    private void Update()
    {
        if (cageState == CageState.IsOpening)
        { 
            if (remainingToOpen <= 0)
            {
                cageState = CageState.IsOpened;
            }
            else
            {
                float rotateAmount = 1 * openingSpeed * Time.deltaTime;
                remainingToOpen -= rotateAmount;
                transform.Rotate(0f, rotateAmount, 0f, Space.World);
            }
        }
    }
}
