using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotionScript : MonoBehaviour
{
    //public PlayerHealth healOnTouch;
    private Animation anim;


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            anim.Play("PlayerGetHealthAnim");
            GameObject Player = GameObject.Find("Player");
            PlayerHealth other = (PlayerHealth)Player.GetComponent(typeof(PlayerHealth));
            other.HealPlayer();

            Destroy(gameObject);
        }
    }
}
