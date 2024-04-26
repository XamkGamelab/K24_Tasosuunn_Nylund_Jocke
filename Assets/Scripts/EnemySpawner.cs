using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Player player;

    public Transform EnemySpawnLocation;
    public GameObject EnemyObject;
    public bool FirstEnemySpawned = false;

    private void Update()
    {
        if (player.EnemyTrigger1 == true && FirstEnemySpawned == false)
        {
            Instantiate(EnemyObject, EnemySpawnLocation);
            FirstEnemySpawned = true;
        }
    }
}
 