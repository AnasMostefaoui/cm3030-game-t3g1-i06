using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    // Platform moves if true
    [SerializeField]
    private bool isMoving = true;
    // True stops the platform at its destination
    [SerializeField]
    private bool isOneDirectional = false;

    // Transform to move from and to
    public Transform startPosition;
    public Transform endPosition;

    // Speed to move
    public float speed = 3f;

    // Start time of movement
    private float startTime;
    // Distance moved
    private float movementDistance;

    private void Start()
    {
        // Set the initial time and movement distance
        PlatformSetup();
    }

    // Update is called once per frame
    void Update()
    {
        // Ensure platform should be moving
        if (isMoving)
        {
            // Calculate the distance moved over time
            float distanceMoved = (Time.time - startTime) * speed;
            // Calculate the fraction of distance traveled
            float fractionOfMovement = distanceMoved / movementDistance;

            // Update the transform
            transform.position = Vector3.Lerp(startPosition.position, endPosition.position, fractionOfMovement);

            // Ensure the playform moves both ways
            if (!isOneDirectional)
            {
                // When the transform reaches the end point
                if (transform.position == endPosition.position)
                {
                    // Switch start and end transforms
                    SwitchTransformTargets(endPosition, startPosition);
                    // Reset time and distance
                    PlatformSetup();
                }
            }
        }
    }

    // Called before a change in movement direction
    private void PlatformSetup()
    {
        // Get the current time
        startTime = Time.time;
        // Set the distance to travel
        movementDistance = Vector3.Distance(startPosition.position, endPosition.position);
    }

    // Switch the direction of travel by changing transforms
    private void SwitchTransformTargets(Transform start, Transform end)
    {
        endPosition = end;
        startPosition = start;
    }
}
