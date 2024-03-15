using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolRotator : MonoBehaviour
{
    public float rotationSpeed = 0.1f;
    public GameObject player_pistol;
    public AudioManager audio_manager;

    private void Update()
    {
        transform.Rotate(0, 0, rotationSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        audio_manager.GunTaken = true;
        player_pistol.SetActive(true);
        Destroy(gameObject);
    }
}
