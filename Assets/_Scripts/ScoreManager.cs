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
    public Text multiplierText;
    public static Action<int> PlayerGotScore;
    public static Action<int> GameOverScoreUpdate;
    public static Action<int> BestScoreUpdate;
    public static Action<int> ScoreChanged;
    public static Action animScore;
    public int bestScore = 0;
    private int multi = 1;

    private void Start()
    {
        bestScore = GetBestScore();

        BestScoreUpdate?.Invoke(bestScore);
        //bestScore = PlayerPrefs.GetInt("BestScore", 0);
    }

    

    private void OnEnable()
    {
        PlayerGotScore += AddScore;
        PlayerManager.PlayerMiss += ResetKillstreak;
        PlayerManager.GotHit += ResetKillstreak;
        PlayerManager.PlayerKill += IncreaseMulti;
    }

    private void OnDisable()
    {
        PlayerGotScore -= AddScore;
        PlayerManager.PlayerMiss -= ResetKillstreak;
        PlayerManager.GotHit -= ResetKillstreak;
        PlayerManager.PlayerKill -= IncreaseMulti;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4)){
            ResetKillstreak();
        }
    }
    private int GetBestScore()
    {
        int score = 0;
        switch (MainMenuManager.difficulty)
        {
            case 0:
                score = PlayerPrefs.GetInt("VeryEasyBestScore", 0);
                break;
            case 1:
                score = PlayerPrefs.GetInt("EasyBestScore", 0);
                break;
            case 2:
                score = PlayerPrefs.GetInt("MediumBestScore", 0);
                break;
            case 3:
                score = PlayerPrefs.GetInt("HardBestScore", 0);
                break;
            case 4:
                score = PlayerPrefs.GetInt("InsaneBestScore", 0);
                break;
        }

        return score;
    }

    private void SetBestScore()
    {
        switch (MainMenuManager.difficulty)
        {
            case 0:
                PlayerPrefs.SetInt("VeryEasyBestScore", bestScore);
                break;
            case 1:
                PlayerPrefs.SetInt("EasyBestScore", bestScore);
                break;
            case 2:
                PlayerPrefs.SetInt("MediumBestScore", bestScore);
                break;
            case 3:
                PlayerPrefs.SetInt("HardBestScore", bestScore);
                break;
            case 4:
                PlayerPrefs.SetInt("InsaneBestScore", bestScore);
                break;
        }

        
    }
    public void AddScore(int points)
    {
        score += points * multi;
        
        //Debug.Log("Points: " + points + " killCount: " + killStreak + " Points * killstreak " + points * killStreak);
        UpdateScoreText();
        ScoreChanged?.Invoke(score);
        GameOverScoreUpdate?.Invoke(score);
        animScore?.Invoke();

        if (score > bestScore)
        {
            bestScore = score;
            SetBestScore();
        }
        BestScoreUpdate?.Invoke(bestScore);
    }

    private void IncreaseMulti()
    {
        Debug.Log("Player Kill Increase multi");
        killStreak++;
        multi = killStreak;
        UpdateMultiplierText();
        AudioManager.instance.PlaySound(AudioManager.instance.SoundBank.MultiplicationAdd);
    }

    private void ResetKillstreak()
    {
        Debug.Log("multi reset");
        killStreak = 0;
        multi = 1;
       UpdateMultiplierText();
    }

    void UpdateScoreText()
    {
        animScore?.Invoke();
        scoreText.text = "Score: " + score;
    }
    void UpdateMultiplierText()
    {
        multiplierText.text = $"{multi}x";
        animScore?.Invoke();
    }
}