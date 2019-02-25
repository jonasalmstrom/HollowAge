using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyHP : MonoBehaviour
{
    public int flyHealth = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            flyHealth -= 1;
            Debug.Log("weee");
        }

    }

    private void Update()
    {
        if (flyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
