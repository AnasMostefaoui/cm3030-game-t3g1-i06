using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrack : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform targetObject;
    public Vector3 offset;
    public PlayersController playersController;

    void Awake()
    {
        Debug.Log("detect", playersController);
        playersController = GetComponent<PlayersController>();
    }

    private void SwitchTarget(GameObject currentPlayer)
    {
        targetObject = currentPlayer.transform;
    }
    void OnEnable()
    {
        PlayersController.OnPlayerSwitch += SwitchTarget;

    }

    void OnDisable()
    {
        PlayersController.OnPlayerSwitch -= SwitchTarget;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = targetObject.position + offset;
    }
}
