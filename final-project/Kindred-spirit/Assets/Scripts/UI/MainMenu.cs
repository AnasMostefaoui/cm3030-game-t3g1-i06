using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameScenes startLevel = GameScenes.Introduction;

    [SerializeField]
    private GameObject mainMenu;

    [SerializeField]
    private GameObject controlMenu;

    [SerializeField]
    private GameObject creditsMenu;

    void Start()
    {
        mainMenu.SetActive(true);
        controlMenu.SetActive(false);
        creditsMenu.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void StartGame()
    {
        // Loads the firsst level and begins a new game
        SceneManager.LoadScene(startLevel.getIndex(), LoadSceneMode.Single);
    }

    public void OpenControlMenu()
    {
        mainMenu.SetActive(false);
        controlMenu.SetActive(true);
    }

    public void CloseControlMenu()
    {
        mainMenu.SetActive(true);
        controlMenu.SetActive(false);
    }

    public void OpenCreditsMenu()
    {
        mainMenu.SetActive(false);
        creditsMenu.SetActive(true);
    }

    public void CloseCreditsMenu()
    {
        mainMenu.SetActive(true);
        creditsMenu.SetActive(false);
    }

    public void OpenLevelSelect()
    {

    }
}
