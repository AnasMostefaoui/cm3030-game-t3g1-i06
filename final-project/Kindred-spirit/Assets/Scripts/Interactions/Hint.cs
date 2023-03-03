using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HintMessageStatus
{
    Hidden,
    FadingIn,
    Visible,
    FadingOut,

}
//[CreateAssetMenu(fileName = "Player Hint", menuName = "Hint")]
public class Hint : MonoBehaviour//ScriptableObject
{
    // Ghost and Player bools to decide if the hint should be displayed depending on the character being controllerd
    public bool isGhostHint = true;
    public bool isPlayerHint = true;

    // The message to display
    public string hintMessage = "This is test hint text. I still need to implement Ghost/Player difference and improve code";

    // Time in Seconds to display the message for
    public float hintTime = 10f;

    // The hint user interface object
    public GameObject hintUI;
    // The hint text for the UI
    public TMPro.TextMeshProUGUI hintTextUI;

    public bool shouldDisplay = false;

    public HintMessageStatus hintStatus = HintMessageStatus.Hidden;

    private void Start()
    {
        hintUI = GameManager.Instance.uiManager.hintUI;
        hintTextUI = GameManager.Instance.uiManager.hintTextUI;
    }
    private void Update()
    {
        if(hintStatus == HintMessageStatus.Visible)
        {
            hintTextUI.text = hintMessage;
            // Activate the hint UI
            hintUI.SetActive(true);
        }
        if (hintStatus == HintMessageStatus.FadingOut)
        {
            // Coroutine to hide hint after a given time
            StartCoroutine(FadeUIElement());
        }
        if(hintStatus == HintMessageStatus.Hidden)
        {
            StopAllCoroutines();
        }
    }


    private IEnumerator FadeUIElement()
    {
        hintTextUI.color = new Color(hintTextUI.color.r, hintTextUI.color.g, hintTextUI.color.b, 1);
        while (hintTextUI.color.a > 0.0f)
        {
            hintTextUI.color = new Color(hintTextUI.color.r, hintTextUI.color.g, hintTextUI.color.b, hintTextUI.color.a - (Time.deltaTime / hintTime));
            yield return null;
        }
        hintStatus = HintMessageStatus.Hidden;
        hintTextUI.color = new Color(hintTextUI.color.r, hintTextUI.color.g, hintTextUI.color.b, 1);
        hintUI.SetActive(false);
        yield return null;
    }


    private void OnTriggerStay(Collider other)
    {
        var hintForPlayer = isPlayerHint && other.gameObject.tag == "Player" && GameManager.Instance.isHumanSelected;
        var hintForGhost = isGhostHint && other.gameObject.tag == "GhostPlayer" && GameManager.Instance.isGhostSelected;
        if (hintForPlayer || hintForGhost)
        {
            hintStatus = HintMessageStatus.Visible;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var hintForPlayer = isPlayerHint && other.gameObject.tag == "Player" && GameManager.Instance.isHumanSelected;
        var hintForGhost = isGhostHint && other.gameObject.tag == "GhostPlayer" && GameManager.Instance.isGhostSelected;
        if (hintForPlayer || hintForGhost)
        {
            hintStatus = HintMessageStatus.FadingOut;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
    }
}
