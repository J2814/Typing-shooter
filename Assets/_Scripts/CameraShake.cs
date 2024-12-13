using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private void OnEnable()
    {
        PlayerManager.GotHit += Shake;
    }
    private void OnDisable()
    {
        PlayerManager.GotHit -= Shake;
    }

    private Vector3 defaultPos;
    private Vector3 punchPos;


    private void Start()
    {
        defaultPos = transform.position;
        punchPos = defaultPos + new Vector3(0, 0.5f, 0);
    }
    private void Shake()
    {
        transform.DOShakePosition(0.25f, 0.17f, 100);
    }
}
