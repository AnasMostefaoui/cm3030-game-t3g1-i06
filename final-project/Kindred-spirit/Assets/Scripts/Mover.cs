using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField]
    public float speed = 10f;
    private Rigidbody rigidBody;
    private Vector3 movementVec;


    // Use this for initialization
    void Start()
    {
        rigidBody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        movementVec = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
    }


    void FixedUpdate()
    {
        moveCharacter(movementVec);
        rigidBody.MoveRotation(Quaternion.LookRotation(rigidBody.velocity));

    }


    void moveCharacter(Vector3 direction)
    {
        rigidBody.velocity = direction * speed;
    }
}
