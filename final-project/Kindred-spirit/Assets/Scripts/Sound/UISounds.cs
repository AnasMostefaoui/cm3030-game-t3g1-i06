using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISounds : MonoBehaviour
{
    [SerializeField]
    GameObject selectSoundObj;
    AudioSource selectSound;

    [SerializeField]
    GameObject confirmSoundObj;
    AudioSource confirmSound;

    private void Start()
    {
        selectSound = selectSoundObj.GetComponent<AudioSource>();
        confirmSound = confirmSoundObj.GetComponent<AudioSource>();
    }


    public void PlaySelect()
    {
        selectSound.Play();
    }

    public void PlayConfirm()
    {
        confirmSound.Play();
    }
}
