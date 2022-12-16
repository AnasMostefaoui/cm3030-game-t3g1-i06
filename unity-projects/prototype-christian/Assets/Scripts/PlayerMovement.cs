using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody playerRb;

    Camera cam;

    [SerializeField]
    float movementSpeed;

    [SerializeField]
    float turnSpeed;

    // Throw Variables
    [SerializeField] float throwStrength;
    [SerializeField] float throwUpForce;
    [SerializeField] float throwDistance;

    string activePlayer;

    [SerializeField]
    GameObject char1;

    [SerializeField]
    GameObject char2;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

        cam = Camera.main;

        activePlayer = "char1";
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        
        float forward = Input.GetAxis("Vertical");
        float side = Input.GetAxisRaw("Horizontal");

        playerRb.MovePosition(transform.position + transform.forward * forward * movementSpeed * Time.deltaTime);

        playerRb.AddTorque(transform.up * side * turnSpeed * Time.deltaTime);

        if(side == 0)
        {
            playerRb.angularVelocity = Vector3.zero;
        }

        // Throw
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject charInst = Instantiate(char2, playerRb.transform.position + (playerRb.transform.forward * 2) , playerRb.transform.rotation);
            Rigidbody charRb = charInst.GetComponent<Rigidbody>();

            charRb.AddForce((playerRb.transform.forward * throwDistance) + (Vector3.up * throwUpForce) * throwStrength * Time.deltaTime, ForceMode.Impulse);

        }
        
    }
}
