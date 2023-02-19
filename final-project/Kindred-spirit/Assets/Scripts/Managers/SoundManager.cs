using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    AudioSource humanSwitchSound;

    [SerializeField]
    AudioSource dogSwitchSound;

    public void PlayHumanSwitch()
    {
        humanSwitchSound.Play();
    }

    public void PlayDogSwitch()
    {
        dogSwitchSound.Play();
    }
}
