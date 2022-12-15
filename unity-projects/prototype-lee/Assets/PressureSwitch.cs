using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureSwitch : MonoBehaviour
{
    [SerializeField]
    private float triggerMass = 3;
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Player") && collision.collider.GetComponent<Rigidbody>().mass >= triggerMass)
        {
            Debug.Log("collision");
        }
    }
}
