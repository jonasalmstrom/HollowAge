using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnockback : MonoBehaviour
{

    public float maxX;
    public float minX;
    public float maxY;
    public float minY;

    private GameObject player;
    private Transform playerTransform;
    private Rigidbody2D rbody;

    // Start is called before the first frame update

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        playerTransform = player.GetComponent<Transform>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.tag == "Weapon")
        {
            
            if (transform.position.x < playerTransform.position.x)
            {
                print("Right");
                rbody.velocity = new Vector2(Random.Range(-maxX, -minX), Random.Range(maxY, minY));
            }

            if (transform.position.x > playerTransform.position.x)
            {
                print("Left");
                rbody.velocity = new Vector2(Random.Range(maxX, minX), Random.Range(maxY, minY));
            }
        }

    }
}
