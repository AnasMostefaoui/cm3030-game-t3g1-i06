using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover : MonoBehaviour
{
    [SerializeField]
    float speed = 5.0f;

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.position = new Vector3(Input.GetAxis("Horizontal"), 0.25f, Input.GetAxis("Vertical")) * speed * Time.deltaTime;
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"),0f, Input.GetAxis("Vertical"));
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
