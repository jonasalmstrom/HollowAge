﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public GameObject lifeHeart;
    public GameObject player;
    public int playerHealth = 3;
    public SpriteRenderer playerDamagedRend;
    GameObject[] deathMenuObjects;


    private void Start()
    {
        deathMenuObjects = GameObject.FindGameObjectsWithTag("ShowOnDeath");
        HideDeathMenu();
    }

    public void OnCollisionEnter2D(Collision2D _collision)
    {
        if (_collision.gameObject.tag == "Damage")
        {
            playerHealth -= 1;
            Debug.Log(string.Format("Health {0}", playerHealth));


            if (playerHealth <= 0)
            {
                ShowDeathMenu();
                print("Death Menu");

            }
            
            lifeHeart.transform.localScale = new Vector2(playerHealth, 1);

        }

        if (_collision.gameObject.tag == "HealingObject")
        {
           
            if (playerHealth <= 0)
            {
                ShowDeathMenu();
                print("Death Menu");
            }
            else
                HideDeathMenu();
           
            lifeHeart.transform.localScale = new Vector2(playerHealth, 1);
            
        }
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
