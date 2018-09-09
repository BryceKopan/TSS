using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]

public class ESphere : ShapeEnemy {
    
    [SerializeField]
        private GameObject explosionPrefab;

    private float moveSpeed = 20f;
    private float attackDelay = 1;

    private SphereCollider sphere;
    private Rigidbody rb;
    private Renderer rend;

    protected override void OnStart()
    {
        sphere = gameObject.GetComponent<SphereCollider>();
        rb = gameObject.GetComponent<Rigidbody>();
        rend = gameObject.GetComponent<Renderer>();

        GameObject go = GameObject.FindWithTag("Player");
        ai = new AI(gameObject.transform, go.transform, 2);
        attackCooldown = 2;
    }

    protected override float GetVolume()
    {
        return (4 / 3) * Mathf.PI * Mathf.Pow(sphere.radius, 3);
    }

    protected override void Move(Vector3 moveDirection)
    {
        rb.AddForce(moveDirection * moveSpeed * Time.deltaTime);
    }

    protected override IEnumerator Attack()
    {
        Color originalColor = rend.material.color;
        rend.material.color = Color.red;
        yield return new WaitForSeconds(attackDelay);
        rend.material.color = originalColor;

        var explosion = (GameObject)Instantiate (
            explosionPrefab,
            gameObject.transform.position,
            gameObject.transform.rotation);
    }
}
