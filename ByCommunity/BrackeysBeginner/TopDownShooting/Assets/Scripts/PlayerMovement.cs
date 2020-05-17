using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    public Camera cam;

    Vector2 movement;
    Vector2 mousePos;

    public float angle;

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        animator.SetFloat("MouseX", Mathf.Clamp(mousePos.x - rb.position.x, -1f, 1f));
        animator.SetFloat("MouseY", Mathf.Clamp(mousePos.y - rb.position.y, -1f, 1f));
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
        
        if(movement.sqrMagnitude <= 0)
        {
            Vector2 lookDir = mousePos - rb.position;

            if (lookDir.magnitude > 0)
            {
                angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90;
                rb.rotation = angle;
            }
        }
    }
}
