using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneHandler : MonoBehaviour
{
    // instance for SceneHandler singleton
    private static SceneHandler instance;

    // Allow public access to SceneHandler singleton instance
    public static SceneHandler Instance { get { return instance; } }

    [SerializeField]
    public int nextScene;

    [SerializeField]
    public int transitionScene;

    [SerializeField]
    private float transitionTime = 2f;
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
        Debug.Log("Loaded scene [" + scene.buildIndex + "] - " + scene.name);
        if (scene.buildIndex == transitionScene)
        {
            StartCoroutine(LoadNextScene());
        }

        if(scene.buildIndex == 3)
        {
            nextScene = 0;
        }
    }

    public void LoadTransition()
    {
        SceneManager.LoadScene(transitionScene, LoadSceneMode.Single);
    }

    IEnumerator LoadNextScene()
    {
        // Wait for the required time
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
    }
}
