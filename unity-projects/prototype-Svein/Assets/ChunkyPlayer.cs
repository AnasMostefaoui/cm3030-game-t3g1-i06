using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkyPlayer : MonoBehaviour
{

    Rigidbody m_Rigidbody;
    float ForceMulitplier;


    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        ForceMulitplier = 50000;

    }

    // Update is called once per frame



    public void UpdateForces(Vector3 dir)
    {
        m_Rigidbody.AddForce(dir * ForceMulitplier);
    }


}