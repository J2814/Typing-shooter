using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        ResetAnimationParameters();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Attack");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetBool("Die", true);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            animator.SetTrigger("Idle");
        }
        else if (Input.GetKey(KeyCode.W))
        {
            animator.SetTrigger("Walk");
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            //animator.SetBool("IsRunning", true);
            animator.SetTrigger("Run");
        }
    }

    private void ResetAnimationParameters()
    {
        animator.SetBool("IsAttacking", false);
        animator.SetBool("IsDead", false);
        animator.SetBool("IsWaiting", false);
        animator.SetBool("IsWalking", false);
        animator.SetBool("IsRunning", false);
    }
}
