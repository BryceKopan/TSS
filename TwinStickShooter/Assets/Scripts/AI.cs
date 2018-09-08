using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI
{
    private Transform playerLocation, entityLocation;

    public AI(Transform entityLocation, Transform playerLocation)
    {
        this.playerLocation = playerLocation;
        this.entityLocation = entityLocation;
    }

    public Vector3 GetMoveDirection()
    {
        return playerLocation.position - entityLocation.position;
    }
}

