using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyHP : MonoBehaviour
{
    public int flyHealth = 1;
    public ParticleSystem enemyMinorBloodSplatter;
    public ParticleSystem enemyBloodSplatter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            flyHealth -= 1;
            Instantiate(enemyMinorBloodSplatter, transform.position, enemyMinorBloodSplatter.transform.rotation);
        }

    }

    private void Update()
    {
        if (flyHealth <= 0)
        {
            Instantiate(enemyBloodSplatter, transform.position, enemyBloodSplatter.transform.rotation);
            Destroy(gameObject);
        }
    }
}
