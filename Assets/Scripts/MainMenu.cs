using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartTutorial()
    {
        SceneManager.LoadScene("Level01");
    }
 
    public void ExitGameMainMenu()
    {
        Application.Quit();
        print("Quit Game");
    }

    public void Credits()
    {
        SceneManager.LoadScene("CreditsScene");
    }
}
