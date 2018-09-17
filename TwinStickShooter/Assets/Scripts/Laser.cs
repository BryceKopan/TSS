using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour 
{
    [SerializeField]
        private const float LaserMaxRange = 50f;

    RaycastHit hit;
    LineRenderer lr;

	// Use this for initialization
	void Start ()
    {
        lr = GetComponent<LineRenderer>();

        SetLRPoints();
	}
	
	// Update is called once per frame
	void Update ()
    {
        SetLRPoints();
	}

    void SetLRPoints()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        lr.SetPosition(0, ray.origin);

        if (Physics.Raycast(ray, out hit, LaserMaxRange))
        {
            lr.SetPosition(1, hit.point);
        }
        else
        {
            lr.SetPosition(1, ray.origin + transform.forward * LaserMaxRange);
        }
    }
}
