using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GhostWall : MonoBehaviour
{
    // Turns the ghost wall on or off
    public void ToggleGhostWall()
    {

        Debug.Log("inside ToggleGhostWall");
        gameObject.SetActive(GameManager.Instance.isGhostSelected);

        //if (gameObject.activeSelf){
        //    gameObject.SetActive(GameManager.Instance.isGhostSelected); 
        //    //TODO  --- Remove the above line for actual implmentation, will alway be active. 
        //    // Will set the material shader to normal
        //    // Will activate the wall collider
        //} else {
        //    gameObject.SetActive(true);
        //    //TODO  --- Remove the above line for actual implmentation, will alway be active. 
        //    // Will set the material shader to have an effect
        //    // Will deactivate the wall collider
        //}
    }
}
