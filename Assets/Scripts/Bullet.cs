using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rb;
    public Transform projectile_bank;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * 375;
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
