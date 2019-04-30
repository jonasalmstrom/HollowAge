using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableWall : MonoBehaviour
{

    public int wallHP = 3;

    public void OnTriggerEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Weapon")
        {
            Debug.Log("sfgdnrnrwnhn");
            wallHP -= 1;
        }


    }

    public void Update()
    {
        if(wallHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
