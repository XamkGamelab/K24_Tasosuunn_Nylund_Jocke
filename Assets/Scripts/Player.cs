using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    public float MoveSpeed = 2;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
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

        float VerticalInput = Input.GetAxis("Mouse Y");
        float HorizontalInput = Input.GetAxis("Mouse X");

        Vector3 playerRotation = transform.rotation.eulerAngles;
        playerRotation.z = 0;
        transform.rotation = Quaternion.Euler(playerRotation);

        transform.Rotate(-VerticalInput, HorizontalInput, 0);


    }
}
