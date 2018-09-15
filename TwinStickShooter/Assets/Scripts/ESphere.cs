using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]

public class ESphere : ShapeEnemy 
{
    [SerializeField]
        private GameObject ExplosionPrefab;
    [SerializeField]
        private float MoveSpeed = 10f;
    [SerializeField]
        private float MaxMoveSpeed = 20f;
    [SerializeField]
        private float AttackDelay = 1;

    private Rigidbody rb;
    private Renderer rend;

    protected override void OnStart()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rend = gameObject.GetComponent<Renderer>();

        GameObject go = GameObject.FindWithTag("Player");
        ai = new AI(gameObject.transform, go.transform, 2);
        attackCooldown = 2;
    }

    protected override void SetStats()
    {
        health = 50;
        damage = 30;
    }

    protected override void Move(Vector3 moveDirection)
    {
        if(rb.velocity.magnitude < MaxMoveSpeed && !attacking)
            rb.AddForce(moveDirection * MoveSpeed * Time.deltaTime);
    }

    protected override IEnumerator Attack()
    {
        attacking = true;

        Color originalColor = rend.material.color;
        rend.material.color = Color.red;
        
        yield return new WaitForSeconds(AttackDelay);
        
        rend.material.color = originalColor;

        GameObject explosion = Instantiate (
            ExplosionPrefab,
            gameObject.transform.position,
            gameObject.transform.rotation);

        ParticleSystem ps = explosion.GetComponent<ParticleSystem>();
        Destroy(explosion, ps.main.duration);
        attacking = false;
    }
}
