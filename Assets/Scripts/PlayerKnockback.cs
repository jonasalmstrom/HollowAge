using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKnockback : MonoBehaviour
{

    public float maxX;
    public float minX;
    public float maxY;
    public float minY;

    private GameObject enemy;
    private Transform enemyTransform;
    private Rigidbody2D rbody;

    // Start is called before the first frame update

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        enemy = GameObject.FindWithTag("Damage");
        enemyTransform = enemy.GetComponent<Transform>();
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Damage")
        {

            if (transform.position.x < enemyTransform.position.x)
            {
                print("Right");
                rbody.velocity = new Vector2(Random.Range(-maxX, -minX), Random.Range(maxY, minY));
            }

            if (transform.position.x > enemyTransform.position.x)
            {
                print("Left");
                rbody.velocity = new Vector2(Random.Range(maxX, minX), Random.Range(maxY, minY));
            }
        }

    }


}
