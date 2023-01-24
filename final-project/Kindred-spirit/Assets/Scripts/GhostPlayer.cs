using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GhostPlayer : MonoBehaviour
{
    // List of all the ghost walls in the scene
    public GameObject[] ghostWalls;
    

    void Start()
    {
        // Find all the ghost Walls
        ghostWalls = GameObject.FindGameObjectsWithTag("GhostWall");
        GetComponent<CapsuleCollider>().radius = GameManager.Instance.spiritManager.spiritLinkRange;
    }

    // Enable spirit link when within radius
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameManager.Instance.spiritManager.hasSpiritLink = true;
        }
    }

    // Disable spirit link when out of radius
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.Instance.spiritManager.hasSpiritLink = false;
        }
    }

    // Called when the player switches to the Ghost
    public void SelectGhost()
    {
        Debug.Log("Selected Ghost");
        ToggleGhostWalls();
    }

    // Called when the player switches to the Human
    public void DeSelectGhost()
    {
        Debug.Log("DeSelected Ghost");
        ToggleGhostWalls();
    }

    // Turns all the Ghost walls on or off
    public void ToggleGhostWalls()
    {
        foreach (GameObject wall in ghostWalls)
        {
            wall.GetComponent<GhostWall>().ToggleGhostWall();
        }
    }
}