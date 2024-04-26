using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public Player player;
    
    public bool BossSpawned;
    public Transform bossSpawnLocation;
    public GameObject bossObject;

    void Update()
    {
        if (player.BossTrigger == true && BossSpawned == false)
        {
            Instantiate(bossObject, bossSpawnLocation);
            BossSpawned = true;
        }
    }
}
