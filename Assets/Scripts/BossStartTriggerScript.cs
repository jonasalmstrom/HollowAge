using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStartTriggerScript : MonoBehaviour
{

    public GameObject babyWolf;
    public GameObject bigWolf;

    public void Start()
    {
        bigWolf.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            babyWolf.SetActive(false);
            bigWolf.SetActive(true);
            Destroy(gameObject);
        }
    }

}
