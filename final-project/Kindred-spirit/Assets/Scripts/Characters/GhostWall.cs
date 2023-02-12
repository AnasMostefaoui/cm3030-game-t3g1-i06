using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GhostWall : MonoBehaviour
{
    public Material defaultMaterial;
    public Material ghostMaterial;

    // Turns the ghost wall on or off
    public void ToggleGhostWall()
    {
        if (GameManager.Instance.isGhostSelected) {
            gameObject.GetComponent<Renderer>().material = defaultMaterial;
            gameObject.GetComponent<MeshCollider>().enabled = true;
            Debug.Log("isHumanSelected");
        } else {
            gameObject.GetComponent<Renderer>().material = ghostMaterial;
            gameObject.GetComponent<MeshCollider>().enabled = false;
            Debug.Log("Ghost selected");
        }
    }
}
