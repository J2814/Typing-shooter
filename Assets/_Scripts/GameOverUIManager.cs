using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUIManager : MonoBehaviour
{
    public Text scoreText;         

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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void UpdateGameOverScore(int finalScore)
    {
        scoreText.text = "Score: " + finalScore;
    }
}
