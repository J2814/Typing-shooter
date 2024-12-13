using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseUIManager : MonoBehaviour
{
    public GameObject pauseMenuUI;

    public Text currentScoreText;
    public Text bestScoreText;

    private bool isPaused = false;

    public static Action PauseEnabled;
    public static Action PauseDisabled;
    private void Start()
    {
        AudioManager.instance.PlayMusic(AudioManager.instance.SoundBank.GameplayMusic);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
                AudioManager.instance.ResumeMusicSource();
            }
            else
            {
                Pause();
                AudioManager.instance.PauseMusicSource();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
        AudioManager.instance.PlaySound(AudioManager.instance.SoundBank.Resume);
        PauseDisabled?.Invoke();
    }

    public void Pause()
    {
        UpdateScoreTexts();
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;

        AudioManager.instance.PlaySound(AudioManager.instance.SoundBank.Pause);
        PauseEnabled?.Invoke();
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");

    }

    private void UpdateScoreTexts()
    {
        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
        if (scoreManager != null)
        {
            currentScoreText.text = $"Current Score: {scoreManager.score}";
            bestScoreText.text = $"Best Score: {scoreManager.bestScore}";
        }
    }
}
