using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCharacterController : MonoBehaviour
{
    int direction;
    bool jump;

    public float walkSpeed = .2f;
    public float jumpSpeed = .2f;

    private void Update()
    {
        direction = 0;
        jump = false;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction = 1; 
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction = -1; 
        }

        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftArrow))
        {
            direction = 0;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            jump = true;
        }

        if(direction != 0 || jump)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(direction * walkSpeed, jump ? jumpSpeed : 0);
            if (direction == -1)
                transform.localScale = new Vector3(-1f, 1f, 1f);
            else
                transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
