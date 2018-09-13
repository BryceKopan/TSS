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

    [SerializeField]
        private GameObject DashEffect;

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
    private bool firing = false;

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

        moveVector = moveDirection.normalized * movementSpeed * Time.deltaTime;

        if(firing)
        {
            moveVector = moveVector * .5f;
            Fire();
        }

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

        transform.LookAt(transform.position + moveDirection);
        transform.position += moveVector;
    }

    private void LateUpdate()
    {
        float rotationAngle = Mathf.Atan2(facingDirection.x, facingDirection.z) * Mathf.Rad2Deg;
        spine.transform.eulerAngles = new Vector3(spine.transform.eulerAngles.x, spine.transform.eulerAngles.y + rotationAngle - transform.eulerAngles.y, spine.transform.eulerAngles.z);
    }

    void handleInput()
    {
        if (Input.GetMouseButtonDown(1))
        {
            aiming = true;
            animator.SetBool("Aiming", aiming);
        }        
        if (Input.GetMouseButtonUp(1))
        {
            aiming = false;
            animator.SetBool("Aiming", aiming);
        }

        if (Input.GetMouseButtonDown(0))
        {
            firing = true;
        }
        if(Input.GetMouseButtonUp(0))
        {
            firing = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Dash();
        }
    }

    void Dash()
    {
        Vector3 oldPosition = transform.position;
        transform.position += moveDirection.normalized * DashDistance;

        var dashEffect = (GameObject)Instantiate(
            DashEffect,
            gameObject.transform.position,
            gameObject.transform.rotation);

        dashEffect.transform.LookAt(oldPosition);
        Debug.DrawLine(oldPosition, transform.position, Color.red, 100);

        ParticleSystem ps = dashEffect.GetComponent<ParticleSystem>();
        Destroy(dashEffect, ps.main.duration);
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

        facingDirection.x = 
            Input.mousePosition.x - Screen.width / 2;
        facingDirection.z = 
            Input.mousePosition.y - Screen.height / 2;

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
