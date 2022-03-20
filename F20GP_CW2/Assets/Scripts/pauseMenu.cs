using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pausePanel;
    public GameObject selectionPanel;
    public GameObject gameUI;

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !selectionPanel.active)
        {
            if (isPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        isPaused = false;
        pausePanel.SetActive(false);
        gameUI.SetActive(true);
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }

    void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        isPaused = true;
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        gameUI.SetActive(false);
    }
}

