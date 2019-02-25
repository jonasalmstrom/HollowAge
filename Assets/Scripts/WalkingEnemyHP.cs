using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEnemyHP : MonoBehaviour
{
    public int walkHealth = 2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            walkHealth -= 1;
            Debug.Log("weee");
        }

    }

    private void Update()
    {
        if (walkHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
