using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SceneData", menuName = "ScriptableObjects/SceneFlowData", order = 1)]
public class SceneFlowData : ScriptableObject
{

    [SerializeField]
    public GameScenes nextScene;

    [SerializeField]
    public GameScenes transitionScene = GameScenes.Transition;
    [SerializeField]
    public float transitionTime;

}
