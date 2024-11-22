using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WordTracker : MonoBehaviour
{
    public static WordTracker instance;
    public List<string> CurrentWords = new List<string>();
    public static Action<string> AddWord;
    public static Action<string> RemoveWord;

    private void OnEnable()
    {
        AddWord += addWord;
        RemoveWord += removeWord;
        InputManager.PlayerShoots += CheckIfPlayerMissed;
    }

    private void OnDisable()
    {
        AddWord -= addWord;
        RemoveWord -= removeWord;
        InputManager.PlayerShoots -= CheckIfPlayerMissed;
    }

    void Awake()
    {
        CurrentWords = new List<string>();
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void addWord(string word)
    {
        CurrentWords.Add(word);
    }
    private void removeWord(string word)
    {
        CurrentWords.Remove(word);
    }
    private void CheckIfPlayerMissed(string word)
    {

        bool wordFound = false;
        foreach (string s in CurrentWords) 
        { 
            if (word.Trim().Equals(s.Trim(), StringComparison.OrdinalIgnoreCase))
            {
                wordFound = true;
                break;
            }
        }

        if (!wordFound)
        {
            Debug.Log("Miss");
            PlayerManager.PlayerMiss?.Invoke();
        }

    }
}
