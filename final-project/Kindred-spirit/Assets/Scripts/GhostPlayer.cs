using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GhostPlayer : MonoBehaviour
{
    public GameObject[] ghostWalls;
<<<<<<< Updated upstream

=======
    
>>>>>>> Stashed changes
    void Start()
    {
        ghostWalls = GameObject.FindGameObjectsWithTag("GhostWall");
    }
    public void SelectGhost()
    {
        Debug.Log("Selected Ghost");
        ToggleGhostWalls();
    }

    public void DeSelectGhost()
    {
        Debug.Log("DeSelected Ghost");
        ToggleGhostWalls();
    }

    public void ToggleGhostWalls()
    {
        foreach (GameObject wall in ghostWalls)
        {
            wall.GetComponent<GhostWall>().ToggleGhostWall();
        }
    }
}
