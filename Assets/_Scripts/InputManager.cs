using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    private string currentInput;
    private KeyCode pressedKey = KeyCode.None;



    public Text TextUi;
    private void DebugTextUi()
    {
        TextUi.text = currentInput;
    }

    void Update()
    {
        EngQwertyInput();

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            ClearInput();
        }
        DebugTextUi();
    }

    private void EngQwertyInput()
    {
        for (KeyCode key = KeyCode.A; key <= KeyCode.Z; ++key)
        {
            if (Input.GetKeyDown(key))
            {
                currentInput += key.ToString().ToLower();
            }
        }
    }

    private void ClearInput()
    {
        currentInput = string.Empty;
    }
}
