using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseUIManager : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject mainMenu;

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        pauseMenuUI.SetActive(false);
        mainMenu.SetActive(true);
    }
}
