using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{
    public float wanderRadius;
    public float wanderTimer;
    public float minDistance = 15;
    public int EnemyHealth = 3;
  
    public bool EnemyFollowing = false;

    public GameObject player;
    public Transform enemy_bank;

    public Player playerScript;

    private Transform target;
    private NavMeshAgent agent;
    private float timer;
    public float Offset = 0.5f;

    void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
    }

    void Start()
    {
        transform.parent = enemy_bank;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (Vector3.Distance(gameObject.transform.position, player.transform.position) < minDistance)
        {
            EnemyFollowing = true;
            Vector3 targetPos = player.transform.position;
            agent.SetDestination(targetPos);

            if (Vector3.Distance(gameObject.transform.position, player.transform.position) < 1)
            {
                agent.SetDestination(transform.position);
                transform.LookAt(player.transform.position);
            }
        }
        else if (timer >= wanderTimer)
        {
            EnemyFollowing = false;
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(newPos);
            timer = 0;
        }

        if (EnemyHealth <= 0)
        {
            if (gameObject.CompareTag("Boss"))
            {
                Destroy(gameObject);
            }

            if (gameObject.CompareTag("Enemy"))
            {
                Destroy(gameObject);
            }
        }

    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = UnityEngine.Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Bullet Hit
        if (collision.collider.CompareTag("Bullet"))
        {
            --EnemyHealth;
        }
    }
}
