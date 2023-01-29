using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField]
    public float speed = 10f;
    private Animator animator;
    public float rotationSpeed = 720f;
    private float Gravity = 20.0f;
    public CharacterController characterController;

    private Vector3 currentMovementVector = Vector3.zero;


    // Use this for initialization
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");
        // Calculate the forward vector relative to the camera
        var CameraForwardDirection = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        var moveVector = verticalInput * CameraForwardDirection + horizontalInput * Camera.main.transform.right;
        if (moveVector.magnitude > 1f)
        {
            moveVector.Normalize();
        }
        // Calculate the rotation for the player
        moveVector = transform.InverseTransformDirection(moveVector);

        // Get Euler angles
        float turnAmount = Mathf.Atan2(moveVector.x, moveVector.z);
        transform.Rotate(0, turnAmount * rotationSpeed * Time.deltaTime, 0);


        if (characterController.isGrounded)
        {
            animator.SetBool("isRunning", moveVector.magnitude > 0);

            currentMovementVector = transform.forward * moveVector.magnitude;
            currentMovementVector *= speed;

        }

        currentMovementVector.y -= Gravity * Time.deltaTime;
        characterController.Move(currentMovementVector * Time.deltaTime);
    }
}
