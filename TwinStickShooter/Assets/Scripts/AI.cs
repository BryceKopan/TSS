using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI
{
    private Transform playerLocation, entityLocation;
    private float attackDistance;

    public AI(Transform entityLocation, Transform playerLocation,
            float attackDistance)
    {
        this.playerLocation = playerLocation;
        this.entityLocation = entityLocation;
        this.attackDistance = attackDistance;
    }

    public bool GetAttack()
    {
        if (Vector3.Distance(playerLocation.position, 
                    entityLocation.position) <= attackDistance)
        {
            return true;
        }
        return false;
    }

    public Vector3 GetMoveDirection()
    {
        Vector3 moveVector;
        moveVector = playerLocation.position - entityLocation.position;
        moveVector.y = 0;
        return moveVector;
    }
}

