using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroductionLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        StartCoroutine(SceneHandler.Instance.LoadNextScene());
    }
    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
