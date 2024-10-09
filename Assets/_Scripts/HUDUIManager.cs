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
    public Text hpText;

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

    //���� ��� HP ��� ������������, ����� ����� ������� ��� ��������� ����
    private void UpdateHPUI(int newHP)
    {
        hpText.text = $"HP: {newHP}";
    }

    private void Start()
    {
        ScoreManager.ScoreChanged?.Invoke(scoreManager.score);
        PlayerManager.HPChanged?.Invoke(playerManager.hp);
    }
}
