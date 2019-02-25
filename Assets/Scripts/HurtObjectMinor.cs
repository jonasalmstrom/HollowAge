using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HurtObjectMinor : MonoBehaviour
{
    public int damage = 0;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            damage = damage + 50;
        }
    }
}
