using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]

public class ESphere : ShapeEnemy {
    private SphereCollider sphere;

    protected override void OnStart()
    {
        sphere = gameObject.GetComponent<SphereCollider>();
    }

    protected override float GetVolume()
    {
        return (4 / 3) * Mathf.PI * Mathf.Pow(sphere.radius, 3);
    }
}
