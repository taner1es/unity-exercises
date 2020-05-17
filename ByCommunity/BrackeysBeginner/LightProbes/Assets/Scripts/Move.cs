using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Rigidbody rb;
    Vector3 dir;

    [SerializeField] float acceleration = 20f;
    [SerializeField] float deceleration = 50f;

    [SerializeField] float speed = 2000f; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        dir.x = Input.GetAxis("Horizontal");    
        dir.z = Input.GetAxis("Vertical");
        
        if(dir.sqrMagnitude > Mathf.Epsilon)
        {
            dir.Normalize();
            dir *= Time.deltaTime;

            rb.velocity = Vector3.Lerp(rb.velocity, dir * speed, 1 / acceleration);
        }
        else
        {
            rb.velocity = Vector3.Lerp(rb.velocity, Vector3.zero, 1 / deceleration);
        }
    }
}
