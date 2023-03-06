using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocus : MonoBehaviour
{
    private Camera mainCamera;
    private Camera focusCamera;
    public float focusTime = 3f;

    private void Start()
    {
        mainCamera = Camera.main.GetComponent<Camera>();
        focusCamera = GetComponent<Camera>();
    }

    private IEnumerator SwitchCameras()
    {
        Debug.Log("Switching Cam");
        SwitchActions();
        yield return new WaitForSeconds(focusTime);
        SwitchActions();
    }

    public void StartCameraFocus()
    {
        StartCoroutine(SwitchCameras());
    }

    private void SwitchActions()
    {
        ToggleCamera();
        ToggleMover();
        ToggleActiveSpiritLink();
    }
    private void ToggleMover()
    {
        if (GameManager.Instance.GetHumanPlayer().GetComponent<HumanPlayer>().canSwitch == true)
        {
            GameManager.Instance.GetHumanPlayer().GetComponent<HumanPlayer>().canSwitch = false;
            GameManager.Instance.GetHumanPlayer().GetComponent<Mover>().enabled = false;
            GameManager.Instance.GetGhostPlayer().GetComponent<Mover>().enabled = false;
        }
        else
        {
            GameManager.Instance.currentPlayer.GetComponent<Mover>().enabled = true;
            GameManager.Instance.GetHumanPlayer().GetComponent<HumanPlayer>().canSwitch = true;
        }
    }

    private void ToggleCamera()
    {
        if (mainCamera.enabled == true)
        {
            focusCamera.enabled = true;
            mainCamera.enabled = false;
        }
        else
        {
            mainCamera.enabled = true;
            focusCamera.enabled = false;
        }
    }

    private void ToggleActiveSpiritLink()
    {
        if (GameManager.Instance.spiritManager.spiritlinkActive == true)
        {
            GameManager.Instance.spiritManager.spiritlinkActive = false;
        }
        else
        {
            GameManager.Instance.spiritManager.spiritlinkActive = true;
        }
    }
}
