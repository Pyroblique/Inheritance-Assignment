using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Header("Enemy")]
   
    public float stoppingDistance = 1;
    public float health = 100f;
    public float damage = 10f;
    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    public Transform target;
    public NavMeshAgent agent;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Attack the player
    public virtual void Update()
    {
        agent.speed = moveSpeed;
        SeekToTarget();
        if(IsAtTarget())
        {
            Attack();
        }
    }

    protected void SeekToTarget()
    {
        if (target != null)
        {
            agent.SetDestination(target.position);
        }
    }

    // If at player, stop moving
    protected bool IsAtTarget()
    {
        if (!agent.hasPath)
            return false;
        return agent.remainingDistance <= stoppingDistance;
    }

    // Regular speed
    public virtual void Attack() {}
}


