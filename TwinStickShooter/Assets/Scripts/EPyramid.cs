using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EPyramid : ShapeEnemy
{
    [SerializeField]
        private float MoveSpeed = 20f;

    private Rigidbody rb;

    protected override void OnStart()
    {
        rb = gameObject.GetComponent<Rigidbody>();

        GameObject go = GameObject.FindWithTag("Player");
        ai = new AI(gameObject.transform, go.transform, 20);
        attackCooldown = 2;
    }

    protected override void SetStats()
    {
        health = 25;
        damage = 15;
    }

    protected override void Move(Vector3 moveDirection)
    {
        rb.AddForce(moveDirection * MoveSpeed * Time.deltaTime);
    }

    protected override IEnumerator Attack()
    {
        yield return null;
    }
}
