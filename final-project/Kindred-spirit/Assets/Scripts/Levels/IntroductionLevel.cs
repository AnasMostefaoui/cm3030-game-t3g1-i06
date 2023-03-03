using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroductionLevel : MonoBehaviour
{
    public SceneFlowData SceneData;
    private void OnEnable()
    {
        StartCoroutine(SceneHandler.LoadNextScene(SceneData));
    }
    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
