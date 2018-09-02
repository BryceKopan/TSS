using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 10f;

    private Vector3 movementDirection;
    private Actions actions;

    // Use this for initialization
    void Start()
    {
        actions = gameObject.GetComponent<Actions>();
    }

    // Update is called once per frame
    void Update()
    {
        handleInput();

        transform.position += movementDirection * movementSpeed * Time.deltaTime;

        if (movementDirection != new Vector3(0, 0, 0))
            actions.Walk();
        else if (movementDirection == new Vector3(0, 0, 0))
            actions.Idle();
    }

    void handleInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            movementDirection += Vector3.forward;
            transform.LookAt(transform.position + movementDirection);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            movementDirection -= Vector3.forward;
            transform.LookAt(transform.position + movementDirection);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            movementDirection += Vector3.left;
            transform.LookAt(transform.position + movementDirection);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            movementDirection -= Vector3.left;
            transform.LookAt(transform.position + movementDirection);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            movementDirection += Vector3.back;
            transform.LookAt(transform.position + movementDirection);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            movementDirection -= Vector3.back;
            transform.LookAt(transform.position + movementDirection);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            movementDirection += Vector3.right;
            transform.LookAt(transform.position + movementDirection);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            movementDirection -= Vector3.right;
            transform.LookAt(transform.position + movementDirection);
        }
    }
}
