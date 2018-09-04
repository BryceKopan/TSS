using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 10f;
 
    [SerializeField]
    private Transform spine;
   
    private Vector3 moveDirection;
    private Vector3 facingDirection;

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
        setMovementAngle();
        setFacingAngle();

        //transform.rotation = Quaternion.Euler(lookDirection);
        Vector3 moveVector;
        moveVector = moveDirection.normalized * movementSpeed * Time.deltaTime;
        transform.position += moveVector;

        //spine.LookAt(facingDirection);
        Debug.Log();

        /*if (movementDirection != new Vector3(0, 0, 0))
            actions.Walk();
        else if (movementDirection == new Vector3(0, 0, 0))
            actions.Idle();
        */
    }

    void handleInput()
    {
    }

    void setMovementAngle()
    {
        //WASD Movement Input
        if (Input.GetKeyDown(KeyCode.W))
            moveDirection += Vector3.forward;
        if (Input.GetKeyUp(KeyCode.W))
            moveDirection -= Vector3.forward;
        if (Input.GetKeyDown(KeyCode.A))
            moveDirection += Vector3.left;
        if (Input.GetKeyUp(KeyCode.A))
            moveDirection -= Vector3.left;
        if (Input.GetKeyDown(KeyCode.S))
            moveDirection += Vector3.back;
        if (Input.GetKeyUp(KeyCode.S))
            moveDirection -= Vector3.back;
        if (Input.GetKeyDown(KeyCode.D))
            moveDirection += Vector3.right;
        if (Input.GetKeyUp(KeyCode.D))
            moveDirection -= Vector3.right;
    }

    void setFacingAngle()
    {
        /*
        //Arrow Keys Facing Input
        if (Input.GetKeyDown(KeyCode.UpArrow))
            facingDirection += Vector3.forward;
        if (Input.GetKeyUp(KeyCode.UpArrow))
            facingDirection -= Vector3.forward;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            facingDirection += Vector3.left;
        if (Input.GetKeyUp(KeyCode.LeftArrow))
            facingDirection -= Vector3.left;
        if (Input.GetKeyDown(KeyCode.DownArrow))
            facingDirection += Vector3.back;
        if (Input.GetKeyUp(KeyCode.DownArrow))
            facingDirection -= Vector3.back;
        if (Input.GetKeyDown(KeyCode.RightArrow))
            facingDirection += Vector3.right;
        if (Input.GetKeyUp(KeyCode.RightArrow))
            facingDirection -= Vector3.right;
        */

        //Mouse Facing Input
        facingDirection.x = Input.mousePosition.x - Screen.width / 2;
        facingDirection.z = Input.mousePosition.y - Screen.height / 2;
    }
}
