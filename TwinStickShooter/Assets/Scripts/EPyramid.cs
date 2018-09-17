using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EPyramid : ShapeEnemy
{
    [SerializeField]
        private GameObject LaserPrefab;
    [SerializeField]
        private float MoveSpeed = 10f;
    [SerializeField]
        private float MaxMoveSpeed = 20f;
    [SerializeField]
        private float AttackDelay = 1;

    private Rigidbody rb;
    private Renderer rend;
    private Transform laserSpawn;

    protected override void OnStart()
    {
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
        laserSpawn = transform.GetChild(0);

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
        if(rb.velocity.magnitude < MaxMoveSpeed && !attacking)
            rb.AddForce(moveDirection * MoveSpeed * Time.deltaTime);

        int speed = 5;

        var targetRotation = Quaternion.LookRotation(transform.position + moveDirection);

        if (!attacking)
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
    }

    protected override IEnumerator Attack()
    {
        attacking = true;
        rb.velocity = new Vector3(0, 0, 0);

        Color originalColor = rend.material.color;
        rend.material.color = Color.red;

        yield return new WaitForSeconds(AttackDelay);

        rend.material.color = originalColor;

        GameObject laser = Instantiate(
                LaserPrefab,
                laserSpawn.position,
                laserSpawn.rotation);

        Destroy(laser, .25f);
        attacking = false;
    }
}
