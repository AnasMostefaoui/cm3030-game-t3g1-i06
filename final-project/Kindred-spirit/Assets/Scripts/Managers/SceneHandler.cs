using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameScenes
{
    MainMenu = 0,
    Transition,
    Introduction,
    Level0,
    Level1,
    Level2,
}

public static class GameScenesExtensions
{
    public static int getIndex(this GameScenes gameScene)
    {
        return (int)gameScene;
    }
}

public class SceneHandler : MonoBehaviour
{
    // instance for SceneHandler singleton
    private static SceneHandler instance;

    // Allow public access to SceneHandler singleton instance
    public static SceneHandler Instance { get { return instance; } }

    private static GameScenes nextScene;
    private static GameScenes transitionScene = GameScenes.Transition;
    private static float transitionTime = 2f;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this; 
        }

        DontDestroyOnLoad(this.gameObject);  
    }
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Loaded scene [" + scene.buildIndex + "] - " + scene.name + " -- " + SceneManager.sceneCountInBuildSettings);
        var sceneData = ScriptableObject.CreateInstance<SceneFlowData>();
        sceneData.nextScene = SceneHandler.nextScene;
        sceneData.transitionScene = SceneHandler.transitionScene;
        sceneData.transitionTime = SceneHandler.transitionTime;

        if (scene.buildIndex == transitionScene.getIndex())
        {
            StartCoroutine(SceneHandler.LoadNextScene(sceneData));
        }
    }

    public static void LoadTransition(SceneFlowData data)
    {
        SceneHandler.transitionScene = data.transitionScene;
        SceneHandler.nextScene = data.nextScene;
        SceneHandler.transitionTime = data.transitionTime;
        SceneManager.LoadScene(SceneHandler.transitionScene.getIndex(), LoadSceneMode.Single);
    }

    public static IEnumerator LoadNextScene(SceneFlowData data )
    {
        SceneHandler.transitionScene = data.transitionScene;
        SceneHandler.nextScene = data.nextScene;
        SceneHandler.transitionTime = data.transitionTime;
        // Wait for the required time
        yield return new WaitForSeconds(data.transitionTime);
        SceneManager.LoadScene(SceneHandler.nextScene.getIndex(), LoadSceneMode.Single);
    }
}
