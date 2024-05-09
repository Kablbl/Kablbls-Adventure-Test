using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip jumpSound;
   

    void Start()
    {
        
            audioSource = GetComponent<AudioSource>();
        
    }

    public void PlayJumpSound()
    {
        audioSource.PlayOneShot(jumpSound);
    }

   
}