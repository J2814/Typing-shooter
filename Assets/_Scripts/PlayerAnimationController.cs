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
            animator.SetBool("IsAttacking", true);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetBool("IsDead", true);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("IsWaiting", true);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("IsWalking", true);
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("IsRunning", true);
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
