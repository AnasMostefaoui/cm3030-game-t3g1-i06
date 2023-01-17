using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GhostWall : MonoBehaviour
{
    public void ToggleGhostWall()
    {
        if (gameObject.activeSelf){
            gameObject.SetActive(false); //Remove this for actual implmentation, will alway be active
            Debug.Log("Ghost walls active: " + gameObject.name);
        } else {
            gameObject.SetActive(true);//Remove this for actual implmentation, will alway be active
            Debug.Log("Ghost walls deactivated: " + gameObject.name);
        }
    }
}
