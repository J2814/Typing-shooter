using System.Collections;
using JetBrains.Annotations;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UI.Image;
using System.Collections.Generic;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;
    public static Action<int> PlayerGotScore; 

    void Start()
    {
        UpdateScoreText();

        PlayerGotScore += AddScore;
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}