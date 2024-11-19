using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Hand : MonoBehaviour
{
    private ParticleSystem shootParticles;

    public static Action<Vector3> LookThere;

    public Transform AimDirection;

    public float RotationResetSpeed;

    private void OnEnable()
    {
        InputManager.PlayerShoots += Shoot;
        LookThere += LookAt;
    }

    private void OnDisable()
    {
        InputManager.PlayerShoots -= Shoot;
        LookThere -= LookAt;
    }

    void Start()
    {
        shootParticles = GetComponentInChildren<ParticleSystem>();
    }

    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(Vector3.zero), Time.deltaTime * RotationResetSpeed);
    }

    private void Shoot(string dumstring)
    {
        if (shootParticles.isPlaying) { shootParticles.Stop(); }
        shootParticles.Play();
        Vector3 rotate = new Vector3(0, AimDirection.transform.position.y, AimDirection.transform.position.z);
        AimDirection.transform.DOLocalRotate(Vector3.zero, 0);
        Vector3 rotPunch = new Vector3(-30, 0, 0);
        AimDirection.transform.DOPunchRotation(rotPunch, 0.3f, 10, 1);
        
    }

    private void LookAt(Vector3 whereToLook)
    {
        Vector3 direction = whereToLook - transform.position;

        direction.y = 0;

        if (direction.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            transform.rotation = targetRotation;
        }
    }
}
