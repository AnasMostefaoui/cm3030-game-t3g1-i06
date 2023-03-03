using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    // The target we are following
    public Transform targetObjectTransform;
    // The distance in the x-z plane to the target
    public float distance = 8.0f;
    // the height we want the camera to be above the target
    public float height = 5.0f;

    public float rotationSpeed = 50f;

    // force the camera to recenter on a target
    public bool shouldRecenter = false;

    public bool shouldRecenterOnLongDistance = true;
    public float recenterDistance = 10f;


    void Start()
    {
        CenterOnTarget();
    }


    void Update()
    {
        // Early out if we don't have a target
        if (!targetObjectTransform || GameManager.Instance.isPaused) return;

        if (shouldRecenter)
        {
            CenterOnTarget();
            shouldRecenter = false;
            return;
        }
        var horizontalInput = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        var verticalInput = Input.GetAxis("Mouse Y") * rotationSpeed * -1 * Time.deltaTime;

        transform.position = targetObjectTransform.position;
        transform.RotateAround(targetObjectTransform.position, targetObjectTransform.right, verticalInput);
        transform.RotateAround(targetObjectTransform.position, targetObjectTransform.up, horizontalInput);

        transform.transform.Translate(new Vector3(0, 0, -distance));
        var clampedYPosition = Mathf.Clamp(transform.position.y, targetObjectTransform.position.y, targetObjectTransform.position.y + height);
        transform.position = new Vector3(transform.position.x, clampedYPosition, transform.position.z);
        // Always look at the target
        transform.LookAt(targetObjectTransform);


    }

    public void SetTarget(Transform newTarget)
    {
        targetObjectTransform = newTarget;
        if(GameManager.Instance.PlayersAreClose(recenterDistance) == false && shouldRecenterOnLongDistance)
        {
            shouldRecenter = true;
            return;
        }
        if(!shouldRecenterOnLongDistance)
        {
            shouldRecenter = true;
            return;
        }
    }


    public void CenterOnTarget()
    {
        if (targetObjectTransform == null) return;
        var yRotation = Quaternion.Euler(0, targetObjectTransform.eulerAngles.y, 0);
        var xRotation = Quaternion.Euler(targetObjectTransform.eulerAngles.x, 0, 0);
        var currentHeight = targetObjectTransform.position.y + (height / 2);

        // Set the position of the camera on the x-z plane to:
        // distance meters behind the target
        transform.position = targetObjectTransform.position;
        transform.position -= yRotation * Vector3.forward * distance;
        transform.position -= xRotation * Vector3.right;

        // Set the height of the camera
        transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);
        //transform.transform.Translate(new Vector3(0, 0, -distance));
        // Always look at the target
        transform.LookAt(targetObjectTransform);
    }
}
