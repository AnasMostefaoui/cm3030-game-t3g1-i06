using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    enum CharacterUISlot
    {
        Human,
        Ghost
    }

    // On screen text to show active player
    public TMPro.TextMeshProUGUI humanPlayerText;
    public TMPro.TextMeshProUGUI ghostPlayerText;

    // UI to Active/Deactive when paused
    public GameObject pauseUI;

    // UI to Active/Deactive when spirit link changed
    public GameObject spiritUI;

    // UI to show on game over
    public GameObject gameOverUI;


    private void Start()
    {
        GameManager.onGameOver += GameOverUI;
    }

    public void refreshUI()
    {
        if (GameManager.Instance.isGhostSelected)
        {
            EnableUISlot(CharacterUISlot.Ghost);
            DisableUISlot(CharacterUISlot.Human);
        }
        else if (GameManager.Instance.isHumanSelected)
        {
            EnableUISlot(CharacterUISlot.Human);
            DisableUISlot(CharacterUISlot.Ghost);
        } 
    }

    private void EnableUISlot(CharacterUISlot uiSlot)
    {
        var textMesh = uiSlot == CharacterUISlot.Human ? humanPlayerText : ghostPlayerText;
        var uiText = uiSlot ==  CharacterUISlot.Human ? "Human" : "Ghost";
        textMesh.text = $"{uiText} Enabled";
        textMesh.color = Color.green;
    }
    private void DisableUISlot(CharacterUISlot uiSlot)
    {
        var textMesh = uiSlot == CharacterUISlot.Human ? humanPlayerText : ghostPlayerText;
        var uiText = uiSlot == CharacterUISlot.Human ? "Human" : "Ghost";
        textMesh.text = $"{uiText} Disabled";
        textMesh.color = Color.red;
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
