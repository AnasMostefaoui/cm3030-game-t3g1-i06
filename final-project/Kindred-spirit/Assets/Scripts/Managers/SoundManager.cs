using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    AudioSource humanSwitchSound;

    [SerializeField]
    AudioSource dogSwitchSound;

    [SerializeField]
    AudioSource spiritBreakSound;

    public void PlayHumanSwitch()
    {
        humanSwitchSound.Play();
    }

    public void PlayDogSwitch()
    {
        dogSwitchSound.Play();
    }

    public void PlaySpiritBreak()
    {
        spiritBreakSound.Play();
    }

    
}
