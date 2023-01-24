using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "Player Hint", menuName = "Hint")]
public class Hint : MonoBehaviour//ScriptableObject
{
    // Ghost and Player bools to decide if the hint should be displayed depending on the character being controllerd
    public bool isGhostHint = true;
    public bool isPlayerHint = true;

    // The message to display
    public string hintMessage = "This is test hint text. I still need to implement Ghost/Player difference and improve code";

    // Time in Seconds to display the message for
    public float hintTime = 4f;

    // The hint user interface object
    public GameObject hintUI;
    // The hint text for the UI
    public TMPro.TextMeshProUGUI hintTextUI;

    private void Update()
    {
        // When the H key is pressed update UI and show hint
        if (Input.GetKeyDown(KeyCode.H))
        {
            // Update the hint Message
            hintTextUI.text = hintMessage;
            // Activate the hint UI
            hintUI.SetActive(true);
            // Coroutine to hide hint after a given time
            StartCoroutine(HideMessage(hintTime));
        }
    }

    // Hides the message after an amount of time
    IEnumerator HideMessage(float hintTimeLength)
    {
        // Wait for the required time
        yield return new WaitForSeconds(hintTimeLength);
        // Hide the Hint UI
        hintUI.SetActive(false);
    }

}
