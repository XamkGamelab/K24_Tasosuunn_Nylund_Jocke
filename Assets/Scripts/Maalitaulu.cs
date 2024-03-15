using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maalitaulu : MonoBehaviour
{
    public bool Hit = false;
    public GameObject valomerkki_light;
    public AudioSource soundManager;
    public AudioClip hit_clip;

    public bool isSoundPlayed = false;

    private void OnCollisionEnter(Collision collision)
    {
        Hit = true;
    }

    private void Update()
    {
        if (Hit == true)
        {
            valomerkki_light.SetActive(true);
            if (isSoundPlayed == false)
            {
                soundManager.PlayOneShot(hit_clip);
            }
            isSoundPlayed = true;
        }
    }
}
