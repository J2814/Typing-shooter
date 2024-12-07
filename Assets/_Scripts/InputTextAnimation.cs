using DG.Tweening;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTextAnimation : MonoBehaviour
{
    private Transform textTransform;

    private void OnEnable()
    {
        InputManager.animKey += textAnimation;
    }

    private void OnDisable()
    {
        InputManager.animKey -= textAnimation;
    }

    private void Start()
    {
        textTransform = transform;
    }

    private void textAnimation()
    {
        textTransform.DOScale(6, 0);
        textTransform.DOPunchScale(new Vector3(0.5f, 0.5f, 0), 0.25f);
    }
}
