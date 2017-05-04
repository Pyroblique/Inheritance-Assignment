using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Spiker : Enemy
{
    public float boostAmount = 20f;
    public float delay = 3f;
    
    void SpeedBoost()
    {
        // Add speed when close to player
        agent.speed = moveSpeed + boostAmount;
    }

    IEnumerator SpeedBoost(float delay)
    {
        // Ability cooldown
        SpeedBoost();
        yield return new WaitForSeconds(delay);
        agent.speed = moveSpeed;
    }

    public override void Attack()
    {
        // Activate speed boost
        StartCoroutine(SpeedBoost(delay));
    }
}
