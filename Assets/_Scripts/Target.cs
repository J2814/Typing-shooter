using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Unity.VisualScripting;
using UnityEngine.XR;
using UnityEngine.UI;

public class Target : MonoBehaviour
{


    private WordCue wordCue;

    [SerializeField]
    private string currentWord;

    private Text text;

    public int ScoreValue;

    public Action OnDeath;

    private bool wordAssigned = false;
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
        text = GetComponentsInChildren<Text>()[0];
        AssignWord();
    }
    private void AssignWord()
    {
        
        currentWord = wordCue.RandomWord();
        text.text = currentWord;
        WordTracker.AddWord?.Invoke(currentWord);
        Debug.Log("Assigned Word is " + currentWord);
        wordAssigned = true;
    }

    private void CheckIfShot(string word)
    {
        Debug.Log("Recieved word: " + word);
        Debug.Log("Expected word: " + currentWord);
        Debug.Log("Check if shot");
        if (word.Trim().Equals(currentWord.Trim(), StringComparison.OrdinalIgnoreCase))
        {
            Hand.LookThere?.Invoke(transform.position);
            Die();
        }
    }

    internal virtual void Die()
    {
      
        ScoreManager.PlayerGotScore?.Invoke(ScoreValue);
        PlayerManager.PlayerKill?.Invoke();
        WordTracker.RemoveWord?.Invoke(currentWord);
        AudioManager.instance.PlaySound(AudioManager.instance.SoundBank.EnemyDeath);

        OnDeath?.Invoke();
        Destroy(this.gameObject);
    }
}
