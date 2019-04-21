using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenuScript : MonoBehaviour
{
    public static DeathMenuScript instance;
    public string lvl;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(GameObject.FindGameObjectWithTag("PauseMenuController"));
        }

        lvl = SceneManager.GetActiveScene().name;

        PlayerPrefs.SetString("lvl", SceneManager.GetActiveScene().name);
        DontDestroyOnLoad(gameObject);
    }
}
