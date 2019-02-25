using UnityEngine;
using System.Collections;

public class CheckPointScript : MonoBehaviour
{
    private GameMaster gm;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Yas");
            gm.lastCheckPointPos = transform.position;
        }
        
    }
}
