using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public CharacterController2D controller;

    float horizontalMove = 0f;
    float runSpeed = 40f;
    bool jump = false;
    bool crouch = false;

    void Start()
    {
        
    }

    void Update()
    {
        Debug.Log(horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed);

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
