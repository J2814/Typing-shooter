using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class Target : MonoBehaviour
{
    private WordCue wordCue;

    [SerializeField]
    private string currentWord;

    private TextMeshProUGUI text;
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
        wordCue = GetComponent<WordCue>();
        text = GetComponentsInChildren<TextMeshProUGUI>()[0];
        AssignWord();
    }

    private void AssignWord()
    {
        currentWord = wordCue.RandomWord();
        text.text = currentWord;
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

    private void Die()
    {
        Destroy(this.gameObject);
    }
}
