using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameOverUIManager : MonoBehaviour
{
    public GameObject gameOverMenu;
    public Text scoreText;
    public Text bestScoreText;

    private void OnEnable()
    {
        ScoreManager.GameOverScoreUpdate += UpdateGameOverScore;
        ScoreManager.BestScoreUpdate += UpdateBestScoreUI;
    }

    private void OnDisable()
    {
        ScoreManager.GameOverScoreUpdate -= UpdateGameOverScore;
        ScoreManager.BestScoreUpdate -= UpdateBestScoreUI;
    }

    public void Retry()
    {
        AudioManager.instance.PlaySound(AudioManager.instance.SoundBank.GenericUiButton);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        AudioManager.instance.PlaySound(AudioManager.instance.SoundBank.GenericUiButton);
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void UpdateGameOverScore(int currentScore)
    {
        scoreText.text = "Score: " + currentScore;

    }

    private void UpdateBestScoreUI(int currentBestScore)
    {
        string bestScoreTextWithoutNumbers = "";

        switch (MainMenuManager.difficulty)
        {
            case 0:
                bestScoreTextWithoutNumbers = "Best Score (Very Easy): ";
                break;
            case 1:
                bestScoreTextWithoutNumbers = "Best Score (Easy): ";
                break;
            case 2:
                bestScoreTextWithoutNumbers = "Best Score (Medium): ";
                break;
            case 3:
                bestScoreTextWithoutNumbers = "Best Score (Hard): ";
                break;
            case 4:
                bestScoreTextWithoutNumbers = "Best Score (Insane): ";
                break;
        }

        bestScoreText.text = bestScoreTextWithoutNumbers + currentBestScore;
    }

    
}
