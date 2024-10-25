using System.Collections;
using JetBrains.Annotations;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UI.Image;
using System.Collections.Generic;
using UnityEditor;
using System.Runtime.CompilerServices;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public int multiStep = 1;
    [SerializeField]
    private int killStreak = 1;
    public Text scoreText;
    public static Action<int> PlayerGotScore;
    public static Action<int> ScoreChanged;

    private void OnEnable()
    {
        PlayerGotScore += AddScore;
        //PlayerManager.PlayerMiss += ResetKillstreak;
        PlayerManager.PlayerKill += IncreaseMulti;
    }

    private void OnDisable()
    {
        PlayerGotScore -= AddScore;
        //PlayerManager.PlayerMiss -= ResetKillstreak;
        PlayerManager.PlayerKill -= IncreaseMulti;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4)){
            ResetKillstreak();
        }
    }

    public void AddScore(int points)
    {
        score += points * killStreak;
        
        //Debug.Log("Points: " + points + " killCount: " + killStreak + " Points * killstreak " + points * killStreak);
        UpdateScoreText();
        ScoreChanged?.Invoke(score);
    }

    private void IncreaseMulti()
    {
        killStreak++;
    }

    private void ResetKillstreak()
    {
        killStreak = 1;
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}