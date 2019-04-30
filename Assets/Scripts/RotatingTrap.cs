using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingTrap : MonoBehaviour
    
{
    
    private PlayerHealth pH;
    
   
    void Start()
    {
        pH = gameObject.GetComponent<PlayerHealth>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("aj");
            pH.playerHealth-= 3;
            
        }
    }
}

