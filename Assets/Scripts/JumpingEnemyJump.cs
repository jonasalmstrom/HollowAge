using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingEnemyJump : MonoBehaviour
{
    public Rigidbody2D rbJumpingEnemy;
    public float enemyJumpHeight = 3;
    public float enemyJumpLength = 3;
    public EnemyHorizontalMovement jumpEnemyMove;
    public bool jumpingGoLeft;

    private void Start()
    {
        rbJumpingEnemy = GetComponent<Rigidbody2D>();
        JumpingMove();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        JumpingMove();
    }

    public void OnCollisionEnter2D(Collision2D collisionGround)
    {
        if (collisionGround.gameObject.tag == "Ground")
        {
            rbJumpingEnemy.velocity = new Vector2(rbJumpingEnemy.velocity.x, enemyJumpHeight);
        }

    }

    public void JumpingMove()
    {
        jumpingGoLeft = !jumpingGoLeft;
        if (jumpingGoLeft == true)
        {
            rbJumpingEnemy.velocity = new Vector2(-enemyJumpLength, enemyJumpHeight);
            transform.localScale = new Vector2(1, 1);
        }
        else
        {
            //annars om den inte är true så sätter den en velocity åt höger 
            rbJumpingEnemy.velocity = new Vector2(enemyJumpLength, enemyJumpHeight);
            transform.localScale = new Vector2(-1, 1);
        }
    }
}
