using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    public AudioSource buttonClickAudioSource;


    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void PlayButtonClickSound()
    {
        AudioClip buttonClickAudio = buttonClickAudioSource.GetComponent<AudioClip>();
        buttonClickAudioSource.PlayOneShot(buttonClickAudio);
    }
}
