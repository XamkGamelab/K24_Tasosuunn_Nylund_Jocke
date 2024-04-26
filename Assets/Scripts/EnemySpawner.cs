using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Player player;

    public Transform EnemySpawnLocation;
    public Transform FirstSpawnLocation;
    public GameObject EnemyObject;
    public bool FirstEnemySpawned = false;
    public bool SecondEnemiesSpawned = false;

    private void Update()
    {
        if (player.EnemyTrigger1 == true && FirstEnemySpawned == false)
        {
            Instantiate(EnemyObject, FirstSpawnLocation);
            FirstEnemySpawned = true;
        }

        if (player.EnemyTrigger2 == true && SecondEnemiesSpawned == false)
        {
            Instantiate(EnemyObject, EnemySpawnLocation);
            SecondEnemiesSpawned = true;
        }
    }
}
 