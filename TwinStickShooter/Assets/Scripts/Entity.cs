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

    }

    void Update()
    {
    }

    void LateUpdate()
    {
    }

    void Attack(Entity entity)
    {
        
    }

    void takeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            dead = true;
        }
    }

    public abstract void death();
}
