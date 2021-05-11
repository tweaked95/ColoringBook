using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    AudioSource jumpSound;
    void Start()
    {
        jumpSound = GetComponent<AudioSource>();
    }

    public void MakeJumpSound()
    {
        jumpSound.Play();
    }
}
