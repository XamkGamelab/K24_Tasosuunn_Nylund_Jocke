using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Player player;

    public Transform EnemySpawnLocation;
    public GameObject EnemyObject;
    public bool EnemySpawned = false;

    private void Update()
    {
        if (player.doorZone == true && EnemySpawned == false)
        {
            Instantiate(EnemyObject, EnemySpawnLocation);
            EnemySpawned = true;
            
        }
    }
}
 