using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public GameObject lifeHeart;
    public int playerHealth = 3;
    public SpriteRenderer playerDamagedRend;
    GameObject[] deathMenuObjects;
    public string lastLevel;
    public Slider healthbar;
    public DeathMenuScript DeathMenuScript;
    public int lvlHP;
    //DeathMenuScript lvl;

    private void Start()
    {
        DeathMenuScript.lvl = lvlHP;
        deathMenuObjects = GameObject.FindGameObjectsWithTag("ShowOnDeath");
        HideDeathMenu();

        PlayerPrefs.SetInt("lvlHP", SceneManager.GetActiveScene().buildIndex);
        lvlHP = PlayerPrefs.GetInt("lvlHP");
    }

    public void HealPlayer()
    {
        playerHealth += 1;
        if (playerHealth >= 3)
        {
            playerHealth = 3;
        }
        Debug.Log(string.Format("Health {0}", playerHealth));
        lifeHeart.transform.localScale = new Vector2(playerHealth, 1);
    }

    public void DamagePlayer()
    {
        playerHealth -= 1;
        Debug.Log(string.Format("Health {0}", playerHealth));


        if (playerHealth <= 0)
        {
            PlayerPrefs.SetInt("lvl", SceneManager.GetActiveScene().buildIndex);
            print(PlayerPrefs.GetInt("lvl"));
            //UnityEditor.EditorApplication.isPaused = true;
            SceneManager.LoadScene("DeathMenuScene");
        }
    }

    public void Update()
    {
        healthbar.value = playerHealth;

        DeathMenuScript.lvl = lvlHP;
    }

    public void OnCollisionEnter2D(Collision2D _collision)
    {
        if (_collision.gameObject.tag == "Damage")
        {
            DamagePlayer();
        }

        if (_collision.gameObject.tag == "HealingObject")
        {
            HealPlayer();
        }
    }

    public void ShowDeathMenu()
    {
        foreach (GameObject g in deathMenuObjects)
        {
            g.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void HideDeathMenu()
    {
        foreach (GameObject g in deathMenuObjects)
        {
            g.SetActive(false);
        }
    }
}
