using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultipleScore : MonoBehaviour
{
    public int score = 0;
    public int scoreMultiplier = 2; 
    public Text scoreText;

    void Start()
    {
        UpdateScoreText();
    }

    public void AddScore(int points)
    {
        score += points * scoreMultiplier;
        UpdateScoreText();
    }

    public void SetScoreMultiplier(int multiplier)
    {
        scoreMultiplier = multiplier; 
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score + " (Multiplier: x" + scoreMultiplier + ")";
    }
}

