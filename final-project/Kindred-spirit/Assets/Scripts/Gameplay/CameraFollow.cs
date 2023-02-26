using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform targetObjectTransform;
    [SerializeField]
    public Vector3 offset;
    public bool lookAtPlayer = false;
    public bool rotateAroundPlayer = false;
    public float rotationSpeed = 5f;

    [Range(0f, 1.0f)]
    public float smoothFactor = 1.0f;
    public float mouseSensitivity  = 1f;
    public float lookSpeed = 2.0f;
    [SerializeField]
    public float lookXLimit = 45.0f;
    float rotationX = 0; 

    void Start()
    {
        offset = transform.position - targetObjectTransform.position;
        offset.x = 0;
    }
    // Update is called once per frame
    void Update()
    {
        //var mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        //transform.localEulerAngles = new Vector3(0, mouseX, 0);

        //rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        //rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        //transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        //transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
         
    }


    void LateUpdate()
    {
        if (GameManager.Instance.isPaused == false) {
            var newPosition = targetObjectTransform.position + offset;
            transform.position = Vector3.Slerp(transform.position, newPosition, smoothFactor);
            var r = transform.rotation;
            //Add this if statement back in if we want click to move to work
            //if ( rotateAroundPlayer && Input.GetMouseButton(0) )
            //{
            var horizontalInput = Input.GetAxis("Mouse X") * rotationSpeed;
            var verticalInput = Input.GetAxis("Mouse Y") * rotationSpeed * -1;

            var cameraTurnAngle = Quaternion.AngleAxis(horizontalInput, Vector3.up);
            offset = cameraTurnAngle * Quaternion.AngleAxis(verticalInput, Vector3.right) * offset;

            offset = Quaternion.AngleAxis(horizontalInput, Vector3.up) * offset;
            offset = Quaternion.AngleAxis(verticalInput, transform.right) * offset;
            offset.y = Mathf.Clamp(offset.y, 0, 10);
            //}

            if (lookAtPlayer)
            {
                transform.LookAt(targetObjectTransform);
            }
        }
    }

    // we should be able to delete this and rely on event instead
    public void SetTarget(Transform newTarget)
    {
        targetObjectTransform = newTarget;
    }
}
