using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody rb;
    public Transform projectile_bank;
    public float projectile_speed = 50;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * projectile_speed;
        transform.parent = projectile_bank;
    }

    private void Update()
    {
        Destroy(gameObject, 3f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
