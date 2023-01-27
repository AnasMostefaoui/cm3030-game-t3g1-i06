using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform targetObject;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        transform.position = targetObject.position + offset;
    }

    public void SetTarget(Transform newTarget)
    {
        targetObject = newTarget;
    }
}
