using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanPlayer : MonoBehaviour, ISelectablePlayer
{
    [SerializeField]
    public bool canSwitch = false;
    public void Select()
    {
        Debug.Log("Selected Player");
    }

    public void Deselect()
    {
        Debug.Log("Deselected Player");
    }

    public void ToggleSwitchAbility() => canSwitch = !canSwitch;
    public void EnableSwitchingAbility() => canSwitch = true;
}
