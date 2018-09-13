using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {
    [SerializeField]
        private float damage = 30f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        GameObject go = other.gameObject;
        Rigidbody rb = go.GetComponent<Rigidbody>();
        Entity ent = go.GetComponent<Entity>();
        
        if(rb)
        {
        }
        if(ent)
        {
            ent.TakeDamage(damage);
        }
    }
}
