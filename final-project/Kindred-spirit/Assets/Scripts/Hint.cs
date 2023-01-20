using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "Player Hint", menuName = "Hint")]
public class Hint : MonoBehaviour//ScriptableObject
{
    public bool isGhostHint = true;
    public bool isPlayerHint = true;
    public string hintMessage = "This is test hint text. I still need to implement Ghost/Player difference and improve code";

    public GameObject hintUI;
    public TMPro.TextMeshProUGUI hintTextUI;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            hintTextUI.text = hintMessage;
            hintUI.SetActive(true);
            StartCoroutine(HideMessage());
        }
    }

    IEnumerator HideMessage()
    {
        yield return new WaitForSeconds(4f);
        hintUI.SetActive(false);
    }

}
