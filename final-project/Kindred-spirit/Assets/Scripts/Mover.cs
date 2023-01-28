using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField]
    public float speed = 10f;
    private Rigidbody rigidBody;
    private Vector3 movementVec;
    private Animator animator;
    public float rotationSpeed = 720f;
    public CharacterController characterController;


    // Use this for initialization
    void Start()
    {
        rigidBody = this.GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        movementVec = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        characterController.Move(movementVec * speed * Time.deltaTime + (new Vector3(0, -9.8f, 0) * Time.deltaTime) );

        if (movementVec.magnitude > 0.1f)
        {
            animator.SetBool("isRunning", true);
            //transform.forward= movementDirection;
            var angleTarget = Mathf.Atan2(movementVec.x , movementVec.z) * Mathf.Rad2Deg;
            var toRotation = Quaternion.LookRotation(movementVec, Vector3.up);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
                transform.rotation =  Quaternion.Euler(0f, angleTarget, 0f);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }


    //void FixedUpdate()
    //{
    //    moveCharacter(movementVec);

    //}


    //void moveCharacter(Vector3 direction)
    //{
    //    transform.position = direction * speed;
    //}
}
