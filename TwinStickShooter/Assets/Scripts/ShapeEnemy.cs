using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShapeEnemy : Entity {
    private float volumeFactor = 100f;
    private AI ai;

    protected override void OnUpdate()
    {
        moveDirection = ai.GetMoveDirection();
    }

    protected override void Death()
    {
        Destroy(gameObject);
    }

    protected override void SetStats()
    {
        health = GetVolume() * volumeFactor;
        damage = GetVolume() * volumeFactor;

        GameObject go = GameObject.FindWithTag("Player");
        ai = new AI(gameObject.transform, go.transform);
    }

    protected abstract float GetVolume();
}
