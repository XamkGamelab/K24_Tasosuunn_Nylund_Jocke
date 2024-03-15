using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip gun_speech;

    public bool GunTaken = false;
    public bool gunSpeechPlayed = false;

    public void Update()
    {
        if (GunTaken == true && gunSpeechPlayed == false)
        {
            gunSpeechPlayed = true;
            audioSource.PlayOneShot(gun_speech);
        }
    }
}
