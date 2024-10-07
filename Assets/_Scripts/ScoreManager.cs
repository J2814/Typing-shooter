using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score = 0; 
    public Text scoreText;

    private void OnEnable()
    {
        InputManager.PlayerKill += MultiplicationAdd;
        InputManager.PlayerMiss += MultiplicationReset;
    }

    private void OnDisable()
    {
        InputManager.PlayerKill -= MultiplicationAdd;
        InputManager.PlayerMiss -= MultiplicationReset;
    }



    void Start()
    {
        UpdateScoreText();
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

    private void MultiplicationAdd()
    {

    }

    private void MultiplicationReset()
    {

    }
}