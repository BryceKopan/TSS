using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]

public class ESphere : ShapeEnemy {
    private float moveSpeed = 20f;
    
    private SphereCollider sphere;
    private Rigidbody rb;

    protected override void OnStart()
    {
        sphere = gameObject.GetComponent<SphereCollider>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    protected override float GetVolume()
    {
        return (4 / 3) * Mathf.PI * Mathf.Pow(sphere.radius, 3);
    }

    protected override void Move(Vector3 moveDirection)
    {
        rb.AddForce(moveDirection * moveSpeed * Time.deltaTime);
    }
}
