using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondSpawner : MonoBehaviour
{
    public Player player;

    public bool SecondEnemySpawned = false;

    public GameObject EnemyObject;
    public Transform SecondSpawnLocation;

    void Update()
    {
        if (player.EnemyTrigger2 == true && SecondEnemySpawned == false)
        {
            Instantiate(EnemyObject, SecondSpawnLocation);
            SecondEnemySpawned = true;
        }
    }
}
