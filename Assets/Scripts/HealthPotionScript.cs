using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotionScript : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            GameObject Player = GameObject.Find("Player");
            PlayerHealth other = (PlayerHealth)Player.GetComponent(typeof(PlayerHealth));
            other.HealPlayer();

            Destroy(gameObject);
        }
    }
}