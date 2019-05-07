using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEnemyHP : MonoBehaviour
{
    public ParticleSystem enemyMinorBloodSplatter;
    public ParticleSystem enemyBloodSplatter;
    public int walkHealth = 2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            walkHealth -= 1;
            Instantiate(enemyMinorBloodSplatter, transform.position, enemyMinorBloodSplatter.transform.rotation);
            
        }

    }

    private void Update()
    {
        if (walkHealth <= 0)
        {
            Instantiate(enemyBloodSplatter, transform.position, enemyBloodSplatter.transform.rotation);
            Destroy(gameObject);
        }
    }
}
