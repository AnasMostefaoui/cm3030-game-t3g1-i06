using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanPlayer : MonoBehaviour, ISelectablePlayer
{
    public void Select()
    {
        Debug.Log("Selected Player");
    }

    public void Deselect()
    {
        Debug.Log("Deselected Player");
    }
}
