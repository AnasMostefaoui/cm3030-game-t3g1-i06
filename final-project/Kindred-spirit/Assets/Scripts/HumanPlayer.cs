using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanPlayer : MonoBehaviour
{
    // Called when the player switched to the human
    public void SelectPlayer()
    {
        Debug.Log("Selected Player");
    }

    // Called when the player switches to the Ghost
    public void DeSelectPlayer()
    {
        Debug.Log("Deselected Player");
    }
}
