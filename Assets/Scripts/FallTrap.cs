using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTrap : MonoBehaviour
{
    SpriteRenderer FallTrapRend;
    public Sprite otherSprite;
    private void Start()
    {
        FallTrapRend = GetComponent<SpriteRenderer>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GetComponent<BoxCollider2D>().enabled = false;

            FallTrapRend.sprite = otherSprite;
        }
    }
}
