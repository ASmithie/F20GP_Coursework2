using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject instructionMenu;

    public void play()
    {
        SceneManager.LoadScene("Level1");
    }

    public void instructions()
    {
        mainMenu.SetActive(false);
        instructionMenu.SetActive(true);
    }

    public void goToMenu()
    {
        mainMenu.SetActive(true);
        instructionMenu.SetActive(false);
    }

    public void quit()
    {
        Application.Quit();
    }
}
