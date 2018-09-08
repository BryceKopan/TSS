using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShapeEnemy : Entity {
    private float volumeFactor = 100f;
    protected float attackCooldown;
    protected AI ai;
    private bool attackOnCooldown = false;

    protected override void OnUpdate()
    {
        moveDirection = ai.GetMoveDirection();
        if(ai.GetAttack() && !attackOnCooldown)
        {
            StartCoroutine(AttackCooldown());
            StartCoroutine(Attack());
        }
    }

    protected override void Death()
    {
        Destroy(gameObject);
    }

    protected override void SetStats()
    {
        health = GetVolume() * volumeFactor;
        damage = GetVolume() * volumeFactor;
    }

    protected abstract float GetVolume();
    protected abstract IEnumerator Attack();

    private IEnumerator AttackCooldown()
    {
        attackOnCooldown = true;
        yield return new WaitForSeconds(attackCooldown);
        attackOnCooldown = false;
    }
}
