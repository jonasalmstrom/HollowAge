using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKnockback : MonoBehaviour
{

    public Rigidbody2D rb;
    public float knockbackX;
    public float knockbackY;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Damage")
        {
            rb.GetComponent<Rigidbody2D>().velocity = new Vector2(knockbackX, knockbackY);
        }
    }
}
