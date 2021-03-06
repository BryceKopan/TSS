﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
        private float BulletDamage = 1f;

    public Vector3 moveVector;
    public float bulletMoveSpeed = 20f;

    // Use this for initialization
    void Start()
    {
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        gameObject.GetComponent<Renderer>().material.color = Color.blue;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += moveVector;
    }

    void OnTriggerEnter(Collider other)
    {
        Entity entity = other.gameObject.GetComponent<Entity>();
        if (entity)
        {
            entity.TakeDamage(BulletDamage);
            Destroy(gameObject);
        }
    }
 
}
