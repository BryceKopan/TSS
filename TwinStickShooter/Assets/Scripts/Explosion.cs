using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {
    
	// Use this for initialization
	void Start () 
    {
        ParticleSystem ps = GetComponent<ParticleSystem>();
	    Destroy(gameObject, ps.main.duration);	
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}
}
