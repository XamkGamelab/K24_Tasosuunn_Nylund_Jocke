using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maalitaulu : MonoBehaviour
{
    public bool Hit = false;
    public GameObject valomerkki_light;

    private void OnCollisionEnter(Collision collision)
    {
        Hit = true;
    }

    private void Update()
    {
        if (Hit == true)
        {
            valomerkki_light.SetActive(true);
        }
    }
}
