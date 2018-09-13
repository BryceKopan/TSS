using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public float SpawnTime;
    public GameObject ToSpawn;

	// Use this for initialization
	void Start () {
	    StartCoroutine(Attack());	
	}

    IEnumerator Attack()
    {
        while(true)
        {
            var spawned = (GameObject)Instantiate (
                    ToSpawn,
                    gameObject.transform.position,
                    gameObject.transform.rotation);
            yield return new WaitForSeconds(SpawnTime);
        }
    }

    // Update is called once per frame
    void Update () {

    }
}
