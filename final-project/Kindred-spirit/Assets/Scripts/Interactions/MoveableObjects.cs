using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableObjects : MonoBehaviour
{
    public GameObject player;
    public Rigidbody rigidBody;
    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        rigidBody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "GhostPlayer")
        {
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {

        rigidBody.isKinematic = GameManager.Instance.isGhostSelected;
    }
}
