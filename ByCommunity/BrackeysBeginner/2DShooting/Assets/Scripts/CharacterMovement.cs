using System.Collections;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public CharacterController2D controller;

    float horizontalMove = 0f;
    float runSpeed = 40f;
    bool jump = false;
    bool justJump = false;
    bool crouch = false;
    Animator animator;
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if(horizontalMove != 0)
        {
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }

        if (Input.GetButtonDown("Jump"))
        {
            if(controller.grounded)
                StartCoroutine("Jump");
        }
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

        //falling
        if (!justJump && controller.grounded)
        {
            animator.SetBool("Jump", false);
        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    IEnumerator Jump() {
        jump = true;
        justJump = true;
        animator.SetBool("Jump", true);

        yield return new WaitForSeconds(.2f);
        justJump = false;
    }
}
