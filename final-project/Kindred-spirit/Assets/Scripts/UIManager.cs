using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI humanPlayerText;
    public TMPro.TextMeshProUGUI ghostPlayerText;

    public GameObject pauseUI;
    public void TogglePlayer()
    {
        if (GameManager.Instance.isGhostSelected)
        {
            EnablePlayerUI();
            DisableGhostUI();
        } else {
            DisablePlayerUI();
            EnableGhostUI();
        }
    }

    public void EnableGhostUI()
    {
        ghostPlayerText.text = "Ghost Enabled";
        ghostPlayerText.color = Color.green;
    }

    void DisableGhostUI()
    {
        ghostPlayerText.text = "Ghost Disabled";
        ghostPlayerText.color = Color.red;
    }

    void EnablePlayerUI()
    {
        humanPlayerText.text = "Player Enabled";
        humanPlayerText.color = Color.green;
    }

    void DisablePlayerUI()
    {
        humanPlayerText.text = "Player Disabled";
        humanPlayerText.color = Color.red;
    }

    public void PauseGameUI()
    {
        pauseUI.SetActive(true);
    }

    public void ResumeGameUI()
    {
        pauseUI.SetActive(false);
    }
}
