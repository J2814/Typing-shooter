using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Unity.VisualScripting;
public class Target : MonoBehaviour
{


    private WordCue wordCue;

    [SerializeField]
    private string currentWord;

    private TextMeshProUGUI text;

    public int ScoreValue;

    public Action OnDeath; 
    private void OnEnable()
    {
        InputManager.PlayerShoots += CheckIfShot;
    }

    private void OnDisable()
    {
        InputManager.PlayerShoots -= CheckIfShot;
    }
    void Start()
    {
        Init();

    }


    protected void Init()
    {
        wordCue = GetComponent<WordCue>();
        text = GetComponentsInChildren<TextMeshProUGUI>()[0];
        AssignWord();
    }
    private void AssignWord()
    {
        
        currentWord = wordCue.RandomWord();
        text.text = currentWord;
        WordTracker.AddWord?.Invoke(currentWord);
        Debug.Log("Assigned Word is " + currentWord);
    }

    private void CheckIfShot(string word)
    {
        Debug.Log("Recieved word: " + word);
        Debug.Log("Expected word: " + currentWord);
        Debug.Log("Check if shot");
        if (word.Trim().Equals(currentWord.Trim(), StringComparison.OrdinalIgnoreCase))
        {
            Die();
        }
    }

    internal virtual void Die()
    {
        ScoreManager.PlayerGotScore?.Invoke(ScoreValue);
        PlayerManager.PlayerKill?.Invoke();
        WordTracker.RemoveWord?.Invoke(currentWord);
        OnDeath?.Invoke();
        Destroy(this.gameObject);
    }
}
