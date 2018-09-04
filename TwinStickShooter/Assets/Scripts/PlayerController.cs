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
    private AnimatorController controller;
    private Animator animator;

    private bool aiming = false;

    // Use this for initialization
    void Start()
    {
        actions = gameObject.GetComponent<Actions>();
        controller = gameObject.GetComponent<AnimatorController>();
        animator = GetComponent<Animator>();

        controller.SetArsenal(controller.arsenal[1].name);
    }

    // Update is called once per frame
    void Update()
    {
        handleInput();
        setMovementAngle();
        setFacingAngle();

        transform.LookAt(transform.position + moveDirection);

        Vector3 moveVector;
        moveVector = moveDirection.normalized * movementSpeed * Time.deltaTime;
        transform.position += moveVector;

        if (moveDirection != new Vector3(0, 0, 0))
            animator.SetFloat("Speed", 0.5f);  
        else if (moveDirection == new Vector3(0, 0, 0))
            animator.SetFloat("Speed", 0f);
    }

    private void LateUpdate()
    {
        float rotationAngle = Mathf.Atan2(facingDirection.x, facingDirection.z) * Mathf.Rad2Deg;
        spine.transform.eulerAngles = new Vector3(spine.transform.eulerAngles.x, spine.transform.eulerAngles.y + rotationAngle - transform.eulerAngles.y, spine.transform.eulerAngles.z);
    }

    void handleInput()
    {
        if (Input.GetMouseButtonDown(1))
            animator.SetBool("Aiming", true);
        else if (Input.GetMouseButtonUp(1))
            animator.SetBool("Aiming", false);
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
