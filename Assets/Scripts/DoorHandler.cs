using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandler : MonoBehaviour
{
    public Maalitaulu maalitaulu_1, maalitaulu_2, maalitaulu_3, maalitaulu_4;
    public Animator door_animator;
    public GameObject spot_light;

    public AudioSource soundManager;
    public AudioClip door_speech;

    public bool SoundPlayed = false;

    private void Update()
    {
        if (maalitaulu_1.Hit == true && maalitaulu_2.Hit == true && maalitaulu_3.Hit == true && maalitaulu_4.Hit == true)
        {
            door_animator.SetBool("DoorOpen", true);
            spot_light.SetActive(true);

            if (SoundPlayed == false)
            {
                SoundPlayed = true;
                soundManager.PlayOneShot(door_speech);
            }
            
        }
    }
}
