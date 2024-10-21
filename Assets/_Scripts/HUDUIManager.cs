using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUDUIManager : MonoBehaviour
{
    public ScoreManager scoreManager;
    public PlayerManager playerManager;

    public Text scoreText;
    //public Text hpText;

    public Image heart1;
    public Image heart2;
    public Image heart3;

    private void OnEnable()
    {
        ScoreManager.ScoreChanged += UpdateScoreUI;
        PlayerManager.HPChanged += UpdateHPUI;
    }

    private void OnDisable()
    {
        ScoreManager.ScoreChanged -= UpdateScoreUI;
        PlayerManager.HPChanged -= UpdateHPUI;
    }

    private void UpdateScoreUI(int newScore)
    {
        scoreText.text = $"Score: {newScore}";
    }

    private void UpdateHPUI(int currentHP)
    {
        //hpText.text = $"HP: {newHP}";
        heart1.gameObject.SetActive(currentHP >= 1);
        heart2.gameObject.SetActive(currentHP >= 2);
        heart3.gameObject.SetActive(currentHP >= 3);
    }


    private void Start()
    {
        ScoreManager.ScoreChanged?.Invoke(scoreManager.score);
        PlayerManager.HPChanged?.Invoke(playerManager.hp);
    }
}
