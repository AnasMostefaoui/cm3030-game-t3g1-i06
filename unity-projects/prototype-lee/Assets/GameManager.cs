using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public GameObject playerOne;
    public GameObject playerOneBG;
    public GameObject playerTwo;
    public GameObject playerTwoBG;
    public Camera followCam;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Player One Selected");
            playerOneBG.SetActive(true);
            playerTwoBG.SetActive(false);
            followCam.GetComponent<FollowObject>().targetObject = playerOne.transform;
            playerOne.GetComponent<mover>().enabled = true;
            playerTwo.GetComponent<mover>().enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("Player Two Selected");
            playerOneBG.SetActive(false);
            playerTwoBG.SetActive(true);
            followCam.GetComponent<FollowObject>().targetObject = playerTwo.transform;
            playerOne.GetComponent<mover>().enabled = false;
            playerTwo.GetComponent<mover>().enabled = true;
        }
    }
}
