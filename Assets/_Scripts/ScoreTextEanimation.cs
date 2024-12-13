using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTextEanimation : MonoBehaviour
{
    private Transform textTransform;

    private void OnEnable()
    {
        ScoreManager.animScore += textAnimation;
    }

    private void OnDisable()
    {
        ScoreManager.animScore -= textAnimation;
    }

    private void Start()
    {
        textTransform = transform;
    }

    private void textAnimation()
    {
        textTransform.DOScale(7, 0);
        textTransform.DOPunchScale(new Vector3(0.5f, 0.5f, 0), 0.25f);
    }
}
