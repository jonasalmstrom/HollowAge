using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotionScript : MonoBehaviour
{
    public ParticleSystem heartParticlePlay;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            
            Instantiate(heartParticlePlay, transform.position, heartParticlePlay.transform.rotation);


            GameObject Player = GameObject.Find("Player");
            PlayerHealth other = (PlayerHealth)Player.GetComponent(typeof(PlayerHealth));
            other.playerHealth += 1;
            Destroy(gameObject);
        }       
    }

    //private void OnColliderEnter2D(Collision2D collision)
    //{

    //}
}