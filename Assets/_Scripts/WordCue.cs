using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class WordCue : MonoBehaviour
{
    public List<string> currentWordSet = new List<string>();
    public TextAsset WordSet;

    private void Awake()
    {
        UpdateWordSet();
    }
    private void UpdateWordSet()
    {
        var content = WordSet.text;
        currentWordSet = new List<string>(content.Split("\n"));
    }
    public string RandomWord()
    {
        string word = currentWordSet[UnityEngine.Random.Range(0, currentWordSet.Count - 1)];
        return word;
    }
}
