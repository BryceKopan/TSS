using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
        private float movementSpeed = 6f;

    [SerializeField]
        private float DashDistance = 6f;

    [SerializeField]
        private Transform spine;

    [SerializeField]
        private GameObject bulletPrefab;

    //[SerializeField]
    //    private Camera camera;

    private Actions actions;
    private AnimatorController controller;
    private Animator animator;
    private Transform bulletSpawn;

    private Vector3 moveVector;
    private Vector3 moveDirection;
    private Vector3 facingDirection;

    private bool aiming = false;

    // Use this for initialization
    void Start()
    {
        actions = gameObject.GetComponent<Actions>();
        controller = gameObject.GetComponent<AnimatorController>();
        animator = GetComponent<Animator>();

        controller.SetArsenal(controller.arsenal[1].name);

        bulletSpawn = GameObject.Find("BulletSpawn").transform;
    }

    // Update is called once per frame
    void Update()
    {
        handleInput();
        setMovementAngle();
        setFacingAngle();

        transform.LookAt(transform.position + moveDirection);

        moveVector = moveDirection.normalized * movementSpeed * Time.deltaTime;
        transform.position += moveVector;

        if (moveDirection != new Vector3(0, 0, 0))
        {
            animator.SetFloat("Speed", 0.5f);
            aiming = false;
            animator.SetBool("Aiming", aiming);
        }
        else if (moveDirection == new Vector3(0, 0, 0))
        {
            animator.SetFloat("Speed", 0f);
        }
    }

    private void LateUpdate()
    {
        float rotationAngle = Mathf.Atan2(facingDirection.x, facingDirection.z) * Mathf.Rad2Deg;
        spine.transform.eulerAngles = new Vector3(spine.transform.eulerAngles.x, spine.transform.eulerAngles.y + rotationAngle - transform.eulerAngles.y, spine.transform.eulerAngles.z);
    }

    void drawLaser()
    {
        if(aiming)
        {

        }
    }

    void handleInput()
    {
        if (Input.GetMouseButtonDown(1))
        {
            aiming = true;
            animator.SetBool("Aiming", aiming);
        }        
        else if (Input.GetMouseButtonUp(1))
        {
            aiming = false;
            animator.SetBool("Aiming", aiming);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Dash();
        }
    }

    void Dash()
    {
        transform.position += moveDirection.normalized * DashDistance;
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
        
        /*RaycastHit hit; 
        Ray ray = camera.ScreenPointToRay(Input.mousePosition); 

        if ( Physics.Raycast (ray, out hit)) 
        {
            facingDirection.x = 
                hit.point.x - gameObject.transform.position.x;
            facingDirection.z = 
                hit.point.z - gameObject.transform.position.z;    
        }
        else
        {*/
            facingDirection.x = 
                Input.mousePosition.x - Screen.width / 2;
            facingDirection.z = 
                Input.mousePosition.y - Screen.height / 2;
        //}

        facingDirection.Normalize();
    }

    void Fire()
    {
        actions.Attack();

        //Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate (
                bulletPrefab,
                bulletSpawn.position,
                bulletSpawn.rotation);

        Bullet bulletScript = bullet.GetComponent<Bullet>();

        //Add velocity to the bullet
        bulletScript.moveVector = facingDirection * bulletScript.bulletMoveSpeed * Time.deltaTime;
        bulletScript.moveVector += moveVector;

        // Destroy the bullet after 2 seconds
        Destroy(bullet, 2.0f);
    }
}
