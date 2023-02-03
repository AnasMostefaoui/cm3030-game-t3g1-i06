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
    [SerializeField]
    public float pushingSpeed = 1f;
    public float rotationSpeed = 720f;
    public CharacterController characterController;

    private bool isPushing = false;
    private float Gravity = 20.0f;
    private Animator animator;
    private Vector3 currentMovementVector = Vector3.zero;


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

    // Update is called once per frame
    void Update()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");

        animator.SetBool("isPushing", false);
        animator.SetBool("isGrabing", false);
        animator.SetBool("isRunning", false);

        if (isPushing == false)
        {
            FreeMovment(horizontalInput, verticalInput);
        } else
        {

            var pushingVector = new Vector3(horizontalInput * pushingSpeed, 0, verticalInput * pushingSpeed);
            var forward = Camera.main.transform.forward;
            var right = Camera.main.transform.right;

            //project forward and right vectors on the horizontal plane (y = 0)
            forward.y = 0f;
            right.y = 0f;
            forward.Normalize();
            right.Normalize();

            //this is the direction in the world space we want to move:
            var desiredMoveDirection = forward * verticalInput + right * horizontalInput;

            if (pushingVector.magnitude > 0)
            {
                animator.SetBool("isPushing", true );
                animator.SetBool("isGrabing", false);
                characterController.Move(desiredMoveDirection * pushingSpeed * Time.deltaTime);
            } else
            {
                animator.SetBool("isPushing", false);
                animator.SetBool("isGrabing", true);
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Moveable" && playerType == PlayerType.Human)
        {
            other.gameObject.transform.parent = null;
            isPushing = false;
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Moveable" && playerType == PlayerType.Human)
        {
            if (Input.GetKey(KeyCode.Space) )
            {
                isPushing = true;
                var vect = new Vector3(0, other.gameObject.transform.position.x, other.gameObject.transform.position.z);
               // transform.LookAt(vect);
                float turnAmount = Mathf.Atan2(other.gameObject.transform.position.x, other.gameObject.transform.position.z);
               //transform.Rotate(0, turnAmount , 0);
                other.gameObject.transform.parent = this.transform;
            } else
            {
                transform.LookAt(null);
                other.gameObject.transform.parent = null;
               isPushing = false;
            }
        }
 
    }
}
