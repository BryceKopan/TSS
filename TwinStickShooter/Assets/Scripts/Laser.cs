using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour 
{
    [SerializeField]
        private const float LaserMaxRange = 50f;

    RaycastHit hit;
    VolumetricLines.VolumetricLineBehavior vlb;

	// Use this for initialization
	void Start ()
    {
        vlb = GameObject.Find("VolumetricLinePrefab").GetComponent<VolumetricLines.VolumetricLineBehavior>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        if(Physics.Raycast(ray, out hit, LaserMaxRange))
        {
            vlb.EndPos = hit.point - ray.origin;
        }
        else
        {
            vlb.EndPos = ray.direction * LaserMaxRange;
        }
        Debug.DrawLine(ray.origin, vlb.EndPos, Color.red, 1);
	}
}
