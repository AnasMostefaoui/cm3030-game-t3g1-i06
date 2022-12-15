using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSeperator : MonoBehaviour
{
    // Start is called before the first frame update


   
    Rigidbody CurrentBody;

    public int ForceMulitplier;
    bool jump;




    public void setTinyBody(Rigidbody rb)
    {
        CurrentBody = rb;
        ForceMulitplier = 30;
        jump = true;
    }
    public void setPercyBody(Rigidbody rb)
    {
        CurrentBody = rb;
        ForceMulitplier = 50;
        jump = false;
    }
    public void setChunkyBody(Rigidbody rb)
    {
        CurrentBody = rb;
        ForceMulitplier = 5000;
        jump = false;
    }

    // Update is called once per frame
    void Update()
    {
        
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

        CurrentBody.AddForce(dir * ForceMulitplier);
    }
}



