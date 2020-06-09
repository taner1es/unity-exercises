using System;
using UnityEngine;

public class CharacterAnimatorController : MonoBehaviour
{
    Animator animator;
    CharacterMovement charMovement;
    CharacterAttack charAttack;

    void Start()
    {
        animator = GetComponent<Animator>();
        charMovement = GetComponent<CharacterMovement>();
        charAttack = GetComponent<CharacterAttack>();
    }

    void FixedUpdate()
    {
        // Grounded
        if(charMovement.controller.m_Grounded)
        {
            animator.SetBool("isWalk", charMovement.horizontalMove != 0);
            animator.SetBool("isJump", charMovement.jump);
            animator.SetBool("isLanding", false);
        }
        else // Fly
        {
            animator.SetBool("isLanding", true);
        }

        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerAttackMelee") && charAttack.meleeAttack)
            animator.SetTrigger("attackMelee");

        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerAttackRange") && charAttack.rangeAttack)
            animator.SetTrigger("attackRange");
    }
}
