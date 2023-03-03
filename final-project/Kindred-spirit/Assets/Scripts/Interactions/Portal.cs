using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{

    public SceneFlowData SceneData;
    private void OnTriggerEnter(Collider other)
    {
        SceneHandler.LoadTransition(SceneData);
    }
}
