using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUIManager : MonoBehaviour
{
    public GameObject gameOverMenu;
    public Text scoreText;
    public Text bestScoreText;

    private void OnEnable()
    {
        ScoreManager.GameOverScoreUpdate += UpdateGameOverScore;
    }

    private void OnDisable()
    {
        ScoreManager.GameOverScoreUpdate -= UpdateGameOverScore;
    }

    public void Retry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void UpdateGameOverScore(int currentScore)
    {
        scoreText.text = "Score: " + currentScore;

        UpdateBestScoreUI();
    }

    private void UpdateBestScoreUI()
    {
        int bestScore = PlayerPrefs.GetInt("BestScore", 0);
        bestScoreText.text = "Best Score: " + bestScore;
    }

    private void Start()
    {
        UpdateBestScoreUI();
    }
}
