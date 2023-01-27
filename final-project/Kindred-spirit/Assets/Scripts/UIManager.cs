using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    // On screen text to show active player
    public TMPro.TextMeshProUGUI humanPlayerText;
    public TMPro.TextMeshProUGUI ghostPlayerText;

    // UI to Active/Deactive when paused
    public GameObject pauseUI;

    // UI to Active/Deactive when spirit link changed
    public GameObject spiritUI;

    // UI to show on game over
    public GameObject gameOverUI;

    // Called when the players are switched
    public void TogglePlayer()
    {
        // Check which player is selected and enable or disable UI's
        if (GameManager.Instance.isGhostSelected)
        {
            EnablePlayerUI();
            DisableGhostUI();
        } else {
            DisablePlayerUI();
            EnableGhostUI();
        }
    }

    // Enable Ghost UI to change text and colour
    public void EnableGhostUI()
    {
        ghostPlayerText.text = "Ghost Enabled";
        ghostPlayerText.color = Color.green;
    }

    // Disable Ghost UI to change text and colour
    void DisableGhostUI()
    {
        ghostPlayerText.text = "Ghost Disabled";
        ghostPlayerText.color = Color.red;
    }

    // Enable Human UI to change text and colour
    void EnablePlayerUI()
    {
        humanPlayerText.text = "Player Enabled";
        humanPlayerText.color = Color.green;
    }

    // Disable Human UI to change text and colour
    void DisablePlayerUI()
    {
        humanPlayerText.text = "Player Disabled";
        humanPlayerText.color = Color.red;
    }

    // Shoud paused UI
    public void PauseGameUI()
    {
        pauseUI.SetActive(true);
    }

    // Hide paused UI
    public void ResumeGameUI()
    {
        pauseUI.SetActive(false);
    }

    // Show game over UI
    public void GameOverUI()
    {
        gameOverUI.SetActive(true);
    }

    // Turn the spirit UI on or off
    public void ToggleSpiritUI()
    {
        if (spiritUI.activeSelf)
        {
            spiritUI.SetActive(false);
        } else {
            spiritUI.SetActive(true);
        }
    }
}
