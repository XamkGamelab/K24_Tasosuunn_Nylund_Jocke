using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    public float CurrentSpeed;
    public float WalkSpeed = 3f;
    public float SprintSpeed = 7f;
    public int CurrentHealth = 100;

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
    public AudioClip reload;

    public GameObject bullet;

    public int MaxAmmo = 10;
    public int CurrentAmmo = 10;
    public TextMeshProUGUI ammotext;
    public GameObject reloadText;
    public GameObject PressR_text;

    public TextMeshProUGUI healthText;
    public GameObject doorText;

    public bool isReloading;
    public bool doorZone;
    public bool doorZone2;
    public bool DamageZone;

    public Animator InteractableDoor;
    public Animator InteractableDoor_2;

    public AudioSource player_source;
    public AudioClip damage_sound;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        healthText.text = CurrentHealth + " / 100";

        // Player Movement

        // Forward
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = transform.forward * CurrentSpeed;
        }

        // Backward
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = -transform.forward * CurrentSpeed;
        }

        // Right
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = transform.right * CurrentSpeed;
        }

        // Left
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = -transform.right * CurrentSpeed;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            CurrentSpeed = SprintSpeed;
        }
        else
        {
            CurrentSpeed = WalkSpeed;
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

        if (Input.GetKeyDown(KeyCode.Mouse0) && PistolTaken == true && CurrentAmmo > 0 && isReloading == false)
        {
            --CurrentAmmo;
            Instantiate(muzzleFlash, pistol_projectile_spawnpoint);
            Instantiate(bullet, pistol_projectile_spawnpoint);
            pistolSource.PlayOneShot(pistol_shot);
        }

        ammotext.text = "Ammo: " + CurrentAmmo + " / 10";

        // Reloading pistol

        if (Input.GetKeyDown(KeyCode.R) && CurrentAmmo <= 9)
        {
            isReloading = true;
            reloadText.SetActive(true);
            PressR_text.SetActive(false);
            pistolSource.PlayOneShot(reload);

            StartCoroutine(ReloadTime());
        }

        if (CurrentAmmo <= 0 && isReloading == false)
        {
            PressR_text.SetActive(true);
        }
        else if (isReloading == true)
        {
            PressR_text.SetActive(false);
        }

        // Door Opening
        if (Input.GetKeyDown(KeyCode.F) && doorZone == true)
        {
            Debug.Log("Open Door");
            InteractableDoor.SetBool("OpenDoor", true);
        }

        // Door 2 Opening
        if (Input.GetKeyDown(KeyCode.F) && doorZone2 == true)
        {
            Debug.Log("Open Door");
            InteractableDoor_2.SetBool("DoorOpen2", true);
        }
    }

    // Checking Door Trigger Zone
    private void OnTriggerEnter(Collider other)
    {
        // Door zone bool changing
        if (other.CompareTag("DoorOpener"))
        {
            doorZone = true;

            doorText.SetActive(true);

        }

        if (other.CompareTag("DoorOpener2"))
        {
            doorZone2 = true;

            doorText.SetActive(true);
        }

        // Damage taking
        if (other.CompareTag("DamageZone"))
        {
            Debug.Log("Damage Zone");
            DamageZone = true;
            StartCoroutine(DamageTaking());
        }
    }

    IEnumerator DamageTaking()
    {
        while (true)
        {
            Debug.Log("Damage taken!");
            player_source.PlayOneShot(damage_sound);
            --CurrentHealth;
            yield return new WaitForSeconds(1);

            if (DamageZone == false)
            break;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        doorZone = false;
        doorZone2 = false;
        DamageZone = false;
        doorText.SetActive(false);
    }

    IEnumerator ReloadTime()
    {
        yield return new WaitForSeconds(4);
        CurrentAmmo = MaxAmmo;
        reloadText.SetActive(false);
        isReloading = false;
    }

    private void OnDrawGizmos()
    {
        Vector3 spawnpoint = pistol_projectile_spawnpoint.transform.position;

        Gizmos.color = Color.red;
        Gizmos.DrawRay(spawnpoint, -pistol_projectile_spawnpoint.right * 30);
    }
}
