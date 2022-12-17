using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersController : MonoBehaviour
{
    public GameObject bigPlayer;
    public GameObject smallPlayer;

    public delegate void PlayerSwitch(GameObject currentPlayer);
    public static event PlayerSwitch OnPlayerSwitch;

    void Start()
    {
        smallPlayer.GetComponent<MovementController>().enabled = false;
        bigPlayer.GetComponent<MovementController>().enabled = true;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            smallPlayer.GetComponent<MovementController>().enabled = false; 
            bigPlayer.GetComponent<MovementController>().enabled = true; 
            OnPlayerSwitch?.Invoke(bigPlayer);
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            bigPlayer.GetComponent<MovementController>().enabled = false; 
            smallPlayer.GetComponent<MovementController>().enabled = true; 
            OnPlayerSwitch?.Invoke(smallPlayer);
        }
        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    Debug.Log("Player One Selected");
        //    playerOneBG.SetActive(true);
        //    playerTwoBG.SetActive(false);
        //    playerOne.GetComponent<mover>().enabled = true;
        //    playerTwo.GetComponent<mover>().enabled = false;
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha2))
        //{
        //    Debug.Log("Player Two Selected");
        //    playerOneBG.SetActive(false);
        //    playerTwoBG.SetActive(true);
        //    followCam.GetComponent<FollowObject>().targetObject = playerTwo.transform;
        //    playerOne.GetComponent<mover>().enabled = false;
        //    playerTwo.GetComponent<mover>().enabled = true;
        //}
    }
}
