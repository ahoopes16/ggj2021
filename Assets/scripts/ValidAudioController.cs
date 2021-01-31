using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidAudioController : MonoBehaviour
{
    private AudioSource _audioSource;
    public AudioClip validSound;
    public AudioClip invalidSound;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void ValidSound() {
        _audioSource.PlayOneShot(validSound, 0.5f);
    }

    public void InvalidSound() {
        _audioSource.PlayOneShot(invalidSound, 0.5f);
    }
}
