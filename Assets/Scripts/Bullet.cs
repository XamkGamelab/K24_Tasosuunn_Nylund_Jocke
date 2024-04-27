using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rb;
    public Transform projectile_bank;
    public GameObject hitParticles;

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
        if (collision.collider.CompareTag("Enemy") || collision.collider.CompareTag("Boss"))
        {
            foreach (var contact in collision.contacts)
            {
                var Hit = Instantiate(hitParticles, contact.point, Quaternion.identity);
            }
        }

        Destroy(gameObject);

    }
}
