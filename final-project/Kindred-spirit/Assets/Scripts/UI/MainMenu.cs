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

    void Start()
    {
        mainMenu.SetActive(true);
        controlMenu.SetActive(false);
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

    public void OpenLevelSelect()
    {

    }

    public void QuitGame()
    {
        // Need to add a confirm screen
        // Application.Quit does not function in editor preview. Will only take effect after build.
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
