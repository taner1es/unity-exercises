using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public float walkSpeed = 0.5f;
    public float turnSpeed = 0.5f;
    public float chargeSpeedMultiplier = 2f;

    private float speed = 0;
    private float rotSpeed = 0;

    Animator animator;
    bool isWalking = false;
    bool isCharging = false;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    private void Update()
    {
        speed = 0;
        rotSpeed = 0;
        isWalking = false;
        isCharging = false;

        if (Input.GetKey(KeyCode.W))
        {
            isWalking = true;
            speed = walkSpeed;   
        }
        if (Input.GetKey(KeyCode.S))
        {
            isWalking = true;
            speed = -walkSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rotSpeed = -turnSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rotSpeed = turnSpeed;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isCharging = true;
            speed *= chargeSpeedMultiplier;
        }


        if (rotSpeed != 0)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + rotSpeed, transform.rotation.eulerAngles.z), .15f);
        if (speed != 0)
        {
            transform.position = Vector3.Lerp(transform.position, transform.position + transform.forward * speed, .15f);
        }

        animator.SetBool("isWalking", isWalking);
        animator.SetBool("isCharging", isCharging && speed != 0);
    }
}
