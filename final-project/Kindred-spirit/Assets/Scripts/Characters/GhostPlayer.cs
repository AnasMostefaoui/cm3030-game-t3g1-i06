using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GhostPlayer : MonoBehaviour, ISelectablePlayer
{
    // List of all the ghost walls in the scene
    public GameObject[] ghostWalls;

    [SerializeField]
    GameObject spiritLineObj;
    LineRenderer spiritLine;


    GameObject playerchar;

    void Start()
    {
        // Find all the ghost Walls
        ghostWalls = GameObject.FindGameObjectsWithTag("GhostWall");
        GetComponent<CapsuleCollider>().radius = GameManager.Instance.spiritManager.spiritLinkRange;

        spiritLine = spiritLineObj.GetComponent<LineRenderer>();
        playerchar = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        
        Vector3 playerPos = playerchar.transform.position;
        spiritLine.SetPosition(0, gameObject.transform.position + new Vector3(0,0.5f,0));
        spiritLine.SetPosition(1, playerPos +new Vector3(0, 0.8f, 0));

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

    // Turns all the Ghost walls on or off
    public void ToggleGhostWalls()
    {
        Debug.Log("ToggleGhostWalls");
        foreach (GameObject wall in ghostWalls)
        {
            wall.GetComponent<GhostWall>().ToggleGhostWall();
        }
    }

    public void Select()
    {
        Debug.Log("Selected Ghost");
        ToggleGhostWalls();
    }

    public void Deselect()
    {
        Debug.Log("DeSelected Ghost");
        ToggleGhostWalls();
    }
}