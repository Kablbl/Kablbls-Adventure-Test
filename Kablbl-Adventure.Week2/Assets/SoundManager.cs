using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip jumpSoundClip;

    private void Start()
    {
     
    }

    public void PlayJumpSound()
    {
        // Play the jumpSoundClip using the audioSource
        audioSource.PlayOneShot(jumpSoundClip);
    }
}