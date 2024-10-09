using System.Collections;
using JetBrains.Annotations;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UI.Image;
using System.Collections.Generic;
using UnityEditor;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;
    public static Action<int> PlayerGotScore;
    public static Action<int> ScoreChanged;

    private void OnEnable()
    {
        PlayerGotScore += AddScore;
    }

    private void OnDisable()
    {
        PlayerGotScore -= AddScore;
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
        ScoreChanged?.Invoke(score);
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}