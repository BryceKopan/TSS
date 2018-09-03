using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCamera : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float height = 10f;
    [SerializeField]
    private float distance = 20f;
    [SerializeField]
    private float angle = 45f;
    [SerializeField]
    private float smoothSpeed = 0.5f;

    private Vector3 refVelocity;
    // Use this for initialization
    void Start()
    {
        HandleCamera();
    }

    // Update is called once per frame
    void Update()
    {
        HandleCamera();
    }

    void HandleCamera()
    {
        if (!target)
            return;

        Vector3 worldPosition = (Vector3.forward * -distance) + (Vector3.up * height);
        worldPosition = Quaternion.AngleAxis(angle, Vector3.up) * worldPosition;

        Vector3 flatTargetPosition = target.position;
        flatTargetPosition.y = 0f;

        worldPosition = flatTargetPosition + worldPosition;

        //transform.position = Vector3.SmoothDamp(transform.position, worldPosition, ref refVelocity, smoothSpeed);
        transform.position = worldPosition;
        transform.LookAt(target.position);
    } 
}
