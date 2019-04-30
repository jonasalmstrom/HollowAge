using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableWall : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Weapon")
        {
            Debug.Log("sfgdnrnrwnhn");
            Destroy(gameObject);
        }
    }
}
