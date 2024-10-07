using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UI.Image;

public class InputManager : MonoBehaviour
{
    private string currentInput;

    public static Action<string> PlayerShoots;

    public Text TextUi;

    public static Action PlayerKill;
    public static Action PlayerMiss;
    private void DebugTextUi()
    {
        TextUi.text = currentInput;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PlayerKill?.Invoke();
            Debug.Log("PlayerKill");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            PlayerMiss?.Invoke();
            Debug.Log("PlayerMiss");
        }


        EngQwertyInput();

        if ((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) && Input.GetKeyDown(KeyCode.Backspace))
        {
            ClearInput();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            ConfirmInput();
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

        if (Input.GetKeyDown(KeyCode.Backspace)){
            currentInput = currentInput.Substring(0, currentInput.Length - 1);
        }
    }

    private void ClearInput()
    {
        currentInput = string.Empty;
    }

    private void ConfirmInput()
    {
        Debug.Log("Current input is " + currentInput);
        PlayerShoots?.Invoke(currentInput);
        ClearInput();
    }
}
