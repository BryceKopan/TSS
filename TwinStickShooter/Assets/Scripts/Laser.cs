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
        vlb = transform.GetChild(0).GetComponent<VolumetricLines.VolumetricLineBehavior>();

        SetVLBPoints();
	}
	
	// Update is called once per frame
	void Update ()
    {
        SetVLBPoints();
	}

    void SetVLBPoints()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        if(Physics.Raycast(ray, out hit, LaserMaxRange))
        {
            vlb.EndPos = new Vector3(0, 0, hit.distance);
            Debug.DrawLine(ray.origin, hit.point, Color.red, 1);
        }
        else
        {
            vlb.EndPos = ray.direction * LaserMaxRange;
            Debug.DrawLine(ray.origin, ray.origin + transform.forward * LaserMaxRange, Color.red, 1);
        }
    }
}
