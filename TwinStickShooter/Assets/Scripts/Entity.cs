using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    protected float health;
    protected float damage;
    private bool dead = false;

    void Start() 
    {
        OnStart();
        SetStats();
    }

    void Update()
    {
    }

    void LateUpdate()
    {
        if (dead)
        {
            Death();
        }
    }

    void Attack(Entity entity)
    {
        entity.TakeDamage(damage);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            dead = true;
        }
    }

    protected abstract void SetStats();
    protected abstract void Death();
    protected abstract void OnStart();
}
