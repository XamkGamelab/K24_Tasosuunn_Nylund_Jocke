using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    public float MoveSpeed = 2;

    public GameObject player_camera;

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    private const float Y_ANGLE_MIN = -85f;
    private const float Y_ANGLE_MAX = 85f;

    public GameObject projectile;
    public Transform projectile_spawnpoint;

    public bool PistolTaken = false;

    public GameObject muzzleFlash;
    public Transform pistol_projectile_spawnpoint;
    public AudioSource pistolSource;
    public AudioClip pistol_shot;

    public GameObject bullet;

    public int MaxAmmo = 10;
    public int CurrentAmmo = 10;
    public TextMeshProUGUI ammotext;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Player Movement

        // Forward
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = transform.forward * MoveSpeed;
        }

        // Backward
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = -transform.forward * MoveSpeed;
        }

        // Right
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = transform.right * MoveSpeed;
        }

        // Left
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = -transform.right * MoveSpeed;
        }

        // Player Rotation

        // Mouse Inputs
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        // Transform camera rotation
        player_camera.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        // Transform player rotation to stay same direction with camera
        transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);

        // Clamp the max/min look angle
        pitch = Mathf.Clamp(pitch, Y_ANGLE_MIN, Y_ANGLE_MAX);

        // Shooting snowballs

        if (Input.GetKeyDown(KeyCode.Mouse0) && PistolTaken == false)
        {
            Instantiate(projectile, projectile_spawnpoint);
        }

        // Shooting with pistol

        if (Input.GetKeyDown(KeyCode.Mouse0) && PistolTaken == true && CurrentAmmo > 0)
        {
            --CurrentAmmo;
            Instantiate(muzzleFlash, pistol_projectile_spawnpoint);
            Instantiate(bullet, pistol_projectile_spawnpoint);
            pistolSource.PlayOneShot(pistol_shot);
        }

        ammotext.text = "Ammo: " + CurrentAmmo + " / 10";

    }

    private void OnDrawGizmos()
    {
        Vector3 spawnpoint = pistol_projectile_spawnpoint.transform.position;

        Gizmos.color = Color.red;
        Gizmos.DrawRay(spawnpoint, -pistol_projectile_spawnpoint.right * 30);
    }
}
