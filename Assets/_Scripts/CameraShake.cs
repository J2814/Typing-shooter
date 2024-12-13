using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private void OnEnable()
    {
        PlayerManager.GotHit += GotDamagedShake;
        InputManager.Shoot += ShootShake;
    }
    private void OnDisable()
    {
        PlayerManager.GotHit -= GotDamagedShake;
        InputManager.Shoot -= ShootShake;
    }

    private Vector3 defaultPos;
    private Vector3 punchPos;


    private void Start()
    {
        defaultPos = transform.position;
        punchPos = defaultPos + new Vector3(0, 0.5f, 0);
    }
    private void GotDamagedShake()
    {
        transform.DOShakePosition(0.25f, 0.17f, 100);
    }

    private void ShootShake()
    {
        transform.DOShakePosition(0.1f, 0.3f, 50);
    }
}
