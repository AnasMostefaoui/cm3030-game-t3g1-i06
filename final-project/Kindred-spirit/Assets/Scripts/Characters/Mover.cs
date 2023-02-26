using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerType
{
    Human,
    Dog,
}

public class Mover : MonoBehaviour
{
    [SerializeField]
    public PlayerType playerType;
    [SerializeField]
    public float speed = 10f;

    public float rotationSpeed = 720f;
    public CharacterController characterController;

    private bool isPushing = false;
    private float Gravity = 20.0f;
    private Animator animator;
    private Vector3 currentMovementVector = Vector3.zero;

    // For Jumping
    private bool isJumping = false;
    public float jumpHeight = 10f;


    public bool moveForwardOnly = false;

    // Use this for initialization
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    void FreeMovment(float horizontalInput, float verticalInput)
    {

        // Calculate the forward vector relative to the camera
        var CameraForwardDirection = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        var moveVector = verticalInput * CameraForwardDirection;
       if(!moveForwardOnly)
        {
            moveVector += horizontalInput * Camera.main.transform.right;
        } 

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
            isJumping = false;

            animator.SetBool("isRunning", moveVector.magnitude > 0);

            currentMovementVector = transform.forward * moveVector.magnitude;
            currentMovementVector *= speed;

            if (Input.GetMouseButtonDown(0))
            {
                isJumping = true;
                currentMovementVector.y += jumpHeight;
            }            
        }
     
        currentMovementVector.y -= Gravity * Time.deltaTime; 
        characterController.Move(currentMovementVector * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");
        animator.SetBool("isRunning", false);


        FreeMovment(horizontalInput, verticalInput);
    }
}
