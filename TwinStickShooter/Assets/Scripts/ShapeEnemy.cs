using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShapeEnemy : Entity {
    private float volumeFactor = 100f;

    protected override void Death()
    {
        Destroy(gameObject);
    }

    protected override void SetStats()
    {
        Debug.Log(GetVolume() * volumeFactor);
        health = GetVolume() * volumeFactor;
        damage = GetVolume() * volumeFactor;
    }

    protected abstract float GetVolume();
}
