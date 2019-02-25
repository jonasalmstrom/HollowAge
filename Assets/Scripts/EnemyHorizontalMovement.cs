using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHorizontalMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public bool goLeft = true;

    private Rigidbody2D rb;
    // Use this for initialization
    void Start()
    {
        //här säger vi till scriptet att vi kommer att använda en rigidbody2d och att den döper vi till "rb"
        rb = GetComponent<Rigidbody2D>();
        Move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Move();
    }
    //jag gör funktionen move för att det ska bli mer clean i scriptet och mer enkelt att se hur allting fungerar
    void Move()
    {
        //om variabeln goLeft är true så sätter den på en velocity på rigibodyn åt vänster
        goLeft = !goLeft;
        if (goLeft == true)
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
        }
        else
        {
            //annars om den inte är true så sätter den en velocity åt höger 
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
        }
    }
}