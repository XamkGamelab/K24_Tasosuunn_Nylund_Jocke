using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    public float timeOn = 0.1f;
    public float timeOff = 0.5f;
    private float changeTime = 0;

    public Light Spotlight;
    public Light Pointlight;

    void Update()
    {
        if (Time.time > changeTime)
        {
            Spotlight.enabled = !Spotlight.enabled;
            Pointlight.enabled = !Pointlight.enabled;
            

            if (Spotlight.enabled)
            {
                changeTime = Time.time + timeOn;
            } else
            {
                changeTime = Time.time + timeOff;
            }
        }
    }
}
