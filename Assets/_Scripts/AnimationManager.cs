using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void SetAnimationState(string state)
    {
        animator.SetBool("IsAttacking", false);
        animator.SetBool("IsDead", false);
        animator.SetBool("IsWaiting", false);
        animator.SetBool("IsWalking", false);
        animator.SetBool("IsRunning", false);

        switch (state)
        {
            case "Attack":
                animator.SetBool("IsAttacking", true);
                break;
            case "Death":
                animator.SetBool("IsDead", true);
                break;
            case "Wait":
                animator.SetBool("IsWaiting", true);
                break;
            case "Walk":
                animator.SetBool("IsWalking", true);
                break;
            case "Run":
                animator.SetBool("IsRunning", true);
                break;
            default:
                Debug.LogWarning("Unknown animation state: " + state);
                break;
        }
    }
}
