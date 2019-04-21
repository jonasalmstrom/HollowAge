using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingEnemyJump : MonoBehaviour
{
    public Rigidbody2D rbJumpingEnemy;
    public float enemyJumpHeight = 3;
    public float enemyJumpLength = 3;
    public EnemyHorizontalMovement jumpEnemyMove;

    private void Start()
    {
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            rbJumpingEnemy.velocity = new Vector2(enemyJumpLength, enemyJumpHeight);
        }
    }
}
