using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private Animator animator;

    public string attackAnimation = "Attack";
    public string deathAnimation = "Death";
    public string idleAnimation = "Idle";
    public string walkAnimation = "Walk";
    public string runAnimation = "Run";

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayAttackAnimation()
    {
        animator.Play(attackAnimation);
    }

    public void PlayDeathAnimation()
    {
        animator.Play(deathAnimation);
    }

    public void PlayIdleAnimation()
    {
        animator.Play(idleAnimation);
    }

    public void PlayWalkAnimation()
    {
        animator.Play(walkAnimation);
    }

    public void PlayRunAnimation()
    {
        animator.Play(runAnimation);
    }

    void Update()
    {
        
    }
}
