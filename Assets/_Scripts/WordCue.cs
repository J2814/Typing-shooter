using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class WordCue : MonoBehaviour
{
    public List<string> currentWordSet = new List<string>();
    public TextAsset WordSet;
    void Start()
    {
        var content = WordSet.text;
        currentWordSet = new List<string>(content.Split("\n"));
    }

    void Update()
    {
        
    }
}
