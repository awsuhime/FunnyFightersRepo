using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    private NavMeshAgent agent;
    public float damage = 5;
    public bool movable = true;

    void Start()
    {
        player = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    

    void Update()
    {
        if (movable)
        {
            agent.isStopped = false;

            agent.SetDestination(new (player.transform.position.x, player.transform.position.y, 0));
        }
        else
        {
            agent.isStopped = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player)
        {
            Health health = player.GetComponent<Health>();
            health.takeDamage(damage);
        }
    }
}
