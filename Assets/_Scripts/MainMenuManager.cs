using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{

    public Button PlayButton,SettingsButton,ExitButton;
    Button newButton;
    public Canvas lp;

  

    public void Start()
    {
        SetClick();
    }

    public void SetClick()
    {
        PlayButton.onClick.AddListener(Play_click);
       SettingsButton.onClick.AddListener(Settings_click);
        ExitButton.onClick.AddListener(Exit_click);
    }
    public void Play_click()
    {
        SceneManager.LoadScene("Test level 3");
    }
    public void Settings_click()
    {
        Offbuttons();
        //GameObject b
    }
    public void Exit_click()
    {
        Application.Quit();
    }
    void Offbuttons()
    {
        PlayButton.gameObject.SetActive(false);
        SettingsButton.gameObject.SetActive(false);
        ExitButton.gameObject.SetActive(false);
       // Instantiate(Canvas);
    }

}
