using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Transform targetObject;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        transform.position = targetObject.position + offset;
    }
}
