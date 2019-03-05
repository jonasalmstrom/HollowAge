using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIgnoreCollisionWithPlayer : MonoBehaviour
{

    public bool shouldMove;
    //private Rigidbody2D rbodyEnemy;

    // Start is called before the first frame update
    void Start()
    {
        shouldMove = true;
        //rbodyEnemy = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            shouldMove = false;
        }
        else
            shouldMove = true;
    }
}
