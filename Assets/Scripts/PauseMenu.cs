using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    GameObject[] pauseObjects;

    // Use this for initialization
    void Start()
    {
        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPaused");
        GameObject Player = GameObject.Find("PauseMenuInGame");
        Time.timeScale = 1;
        HidePaused();
    }

    // Update is called once per frame
    void Update()
    {

        //uses the p button to pause and unpause the game
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                ShowPaused();
            }
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                HidePaused();
            }
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            SceneManager.LoadScene(0);
            Debug.Log("SFSDd");
        }

        if (Time.timeScale == 1)
        {
            HidePaused();
        }
    }

    //Reloads the Level
    public void Reload()
    {
        HidePaused();
        string s = PlayerPrefs.GetString("lvl");
        SceneManager.LoadScene(s);
    }

    //controls the pausing of the scene
    public void PauseControl()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            ShowPaused();
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            HidePaused();
        }
    }

    //shows objects with ShowOnPause tag
    public void ShowPaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(true);
        }
    }

    //hides objects with ShowOnPause tag
    public void HidePaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }
    }

    //loads inputted level
    public void LoadMainMenu(string level)
    {
        HidePaused();
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        HidePaused();
        Application.Quit();
        print("quit");
    }
}

