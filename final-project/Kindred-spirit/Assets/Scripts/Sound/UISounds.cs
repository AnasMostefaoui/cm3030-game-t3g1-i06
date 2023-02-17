using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISounds : MonoBehaviour
{
    [SerializeField]
    AudioSource selectSound;

    [SerializeField]
    AudioSource confirmSound;

    [SerializeField]
    AudioSource backSound;

    public void PlaySelect()
    {
        selectSound.Play();
    }

    public void PlayConfirm()
    {
        confirmSound.Play();
    }

    public void PlayBack()
    {
        backSound.Play();
    }
}
