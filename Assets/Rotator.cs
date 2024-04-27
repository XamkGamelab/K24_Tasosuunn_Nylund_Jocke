using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 0.1f;
    public GameObject key;
   
    private void Update()
    {
        transform.Rotate(0, rotationSpeed, 0);
    }

}
