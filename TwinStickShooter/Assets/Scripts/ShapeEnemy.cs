using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShapeEnemy : Entity {

    protected override void Death()
    {
        Destroy(gameObject);
    }

    protected override void SetStats()
    {
        Debug.Log(GetVolume());
        health = GetVolume();
        damage = GetVolume();
    }

    protected abstract float GetVolume();
}
