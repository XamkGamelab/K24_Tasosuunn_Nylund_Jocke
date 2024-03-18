using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public DoorHandler doorhandler;

    public Transform EnemySpawnLocation;
    public GameObject EnemyObject;
    public bool EnemySpawned = false;

    private void Update()
    {
        if (doorhandler.firstDoorOpened == true && EnemySpawned == false)
        {
            Instantiate(EnemyObject, EnemySpawnLocation);
            EnemySpawned = true;
            
        }
    }
}
 