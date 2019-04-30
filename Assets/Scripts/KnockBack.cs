using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{

    public Rigidbody2D rb1;
    public float knockbackX1;
    public float knockbackY2;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            rb1.GetComponent<Rigidbody2D>().velocity = new Vector2(knockbackX1, knockbackY2);
        }
    }
}