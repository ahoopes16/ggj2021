using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidsYelling : MonoBehaviour
{
    public AudioClip kidsYelling;
    private AudioSource audioManager;
    void Start()
    {
        audioManager = GetComponent<AudioSource>();
    }

    public void MakeKidsYell() {
        audioManager.PlayOneShot(kidsYelling, 0.2f);
    }
}
