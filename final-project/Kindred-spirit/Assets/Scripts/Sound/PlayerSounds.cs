using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    AudioSource footstepSound;

    void Start()
    {
        footstepSound = gameObject.GetComponent<AudioSource>();
    }

    public void playStep()
    {
        footstepSound.Play();
    }
}
