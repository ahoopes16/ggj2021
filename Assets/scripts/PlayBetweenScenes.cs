using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBetweenScenes : MonoBehaviour
{
    private AudioSource _audioSource;
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
 
    public void PlayMusic()
    {
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource.isPlaying) return;
        _audioSource.Play();
    }
 
    public void StopMusic()
    {
        _audioSource = GetComponent<AudioSource>();
         _audioSource.Stop();
    }
}