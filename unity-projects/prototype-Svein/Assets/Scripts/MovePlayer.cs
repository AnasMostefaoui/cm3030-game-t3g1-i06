using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    Rigidbody m_Rigidbody;
    float ForceMulitplier;
    public Camera cameraRef;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        ForceMulitplier = 50000;
        
    }

    

    // Update is called once per frame
    void Update()
    {
        //m_Rigidbody.AddForce(transform.right *15);
        //cameraRef.transform.position = transform.position + new Vector3(1,0, 0);
        //Debug.Log("Update");

        Debug.Log(transform.position);

    }

    private void FixedUpdate()
    {


        Vector3 dir = new Vector3(0.0f, 0.0f, 0.0f);
        if (Input.GetKey(KeyCode.W))
        {
            dir += Vector3.forward; //Debug.Log("fixedUpdate W");
        }
        if (Input.GetKey(KeyCode.S))
        {
            dir += Vector3.back;
        }
        if (Input.GetKey(KeyCode.A))
        {
            dir += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            dir += Vector3.right;
        }
        //Debug.Log("fixedUpdate");
        m_Rigidbody.AddForce(dir * ForceMulitplier);
        
    }
}
