using System.Collections;
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
    public float FadingSpeed;

    public GameObject humanIcon;
    public GameObject dogIcon;

    // UI to Active/Deactive when paused
    public GameObject pauseUI;

    // UI to Active/Deactive when spirit link changed
    public GameObject spiritUI;

    // UI to show on game over
    public GameObject gameOverUI;

    public GameObject tutorialSwitchHint;

    // The hint user interface object
    public GameObject hintUI;
    // The hint text for the UI
    public TMPro.TextMeshProUGUI hintTextUI;

    private bool switchHintShowed = false;
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
        //var textMesh = uiSlot == CharacterUISlot.Human ? humanPlayerText : ghostPlayerText;
        //var uiText = uiSlot ==  CharacterUISlot.Human ? "Human" : "Ghost";
        //textMesh.text = $"{uiText} Enabled";
        //textMesh.color = Color.green;
        if (uiSlot == CharacterUISlot.Human){
            humanIcon.SetActive(true);
            dogIcon.SetActive(false);
        } else
        {
            humanIcon.SetActive(false);
            dogIcon.SetActive(true);
        }
    }
    private void DisableUISlot(CharacterUISlot uiSlot)
    {
        //var textMesh = uiSlot == CharacterUISlot.Human ? humanPlayerText : ghostPlayerText;
        //var uiText = uiSlot == CharacterUISlot.Human ? "Human" : "Ghost";
        //textMesh.text = $"{uiText} Disabled";
        //textMesh.color = Color.red;
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

    public void TutorialSwitchCharacterHint()
    {
        if (switchHintShowed) return;
        tutorialSwitchHint.SetActive(true);
        StartCoroutine(FadeUIElement(tutorialSwitchHint.GetComponentInChildren<Text>()));
    }

    private IEnumerator FadeUIElement( Text element)
    {
        element.color = new Color(element.color.r, element.color.g, element.color.b, 1);
        while (element.color.a > 0.0f)
        {
            element.color = new Color(element.color.r, element  .color.g, element   .color.b, element.color.a - (Time.deltaTime / FadingSpeed));
            yield return null;
        }
        element.gameObject.SetActive(false);
        yield return null;
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
