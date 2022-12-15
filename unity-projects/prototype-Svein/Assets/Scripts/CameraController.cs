using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Tiny;
    public GameObject Percy;
    public GameObject Chunky;

    GameObject currentObject;
   

    public MovementSeperator MS;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        //MS = new MovementSeperator();
        // MS.change
        
        currentObject = Chunky;
        offset = transform.position - currentObject.transform.position;
        MS.setChunkyBody(Chunky.GetComponent<Rigidbody>());
    }

   

    private void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            //transform.parent = Tiny.transform;
            
            MS.setTinyBody(Tiny.GetComponent<Rigidbody>());
            currentObject = Tiny;
        }
        else if (Input.GetKey(KeyCode.X))
        {
            //transform.parent = Percy.transform;
            currentObject = Percy;
            
            MS.setPercyBody(Percy.GetComponent<Rigidbody>());
        }
        else if (Input.GetKey(KeyCode.C))
        {
            //transform.parent = Chunky.transform;
            currentObject = Chunky;
            MS.setChunkyBody(Chunky.GetComponent<Rigidbody>());
        }
       
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        transform.position = currentObject.transform.position + offset;
        //Debug.Log(transform.position);
    }
}
