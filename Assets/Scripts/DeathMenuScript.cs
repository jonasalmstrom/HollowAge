using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenuScript : MonoBehaviour
{

    public PlayerHealth PlayerHealth;
    public static DeathMenuScript instance;
    public int lvl;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(GameObject.FindGameObjectWithTag("PauseMenuController"));
        }


    }

    private void Update()
    {
        print(lvl);

        if (PlayerHealth.playerHealth <= 0)
        {
            PlayerPrefs.SetInt("lvl", SceneManager.GetActiveScene().buildIndex);
            lvl = PlayerPrefs.GetInt("lvl");
            //lvl = SceneManager.GetActiveScene().buildIndex;
        }
    }
}
