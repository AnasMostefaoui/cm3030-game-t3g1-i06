using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GhostPlayer : MonoBehaviour
{
    // List of all the ghost walls in the scene
    public GameObject[] ghostWalls;
    // Check if the characters are close enough to link
    private bool hasSpiritLink = false;
    // Rate of change
    public float rateOfSpiritIncrease = 5.0f;
    public float rateOfSpiriTDecrease = 2.0f;
    // Collider for spirit Range
    public float spiritColliderRange = 6.0f;

    void Start()
    {
        // Find all the ghost Walls
        ghostWalls = GameObject.FindGameObjectsWithTag("GhostWall");
        GetComponent<CapsuleCollider>().radius = spiritColliderRange;
    }

    private void Update()
    {
        // Check the spirit link is in use
        if (GameManager.Instance.spiritlinkActive)
        {
            // Add or remove spirit health depending on spirit link
            if (hasSpiritLink && GameManager.Instance.spiritHealth < 100)
            {
                GameManager.Instance.spiritHealth += Time.deltaTime * rateOfSpiritIncrease;
            }
            else if (!hasSpiritLink && GameManager.Instance.spiritHealth > 0)
            {
                GameManager.Instance.spiritHealth -= Time.deltaTime * rateOfSpiriTDecrease;
            }
        }
    }

    // Enable spirit link when within radius
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            hasSpiritLink = true;
        }
    }

    // Disable spirit link when out of radius
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            hasSpiritLink = false;
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