using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotionScript : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            GameObject Player = GameObject.Find("Player");
            PlayerHealth playerScript = Player.GetComponent<PlayerHealth>();
            playerScript.playerHealth += 1;

            Destroy(gameObject);
        }
    }
}
