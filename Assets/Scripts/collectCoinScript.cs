using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectCoinScript : MonoBehaviour
{
    public float coin = 1;
    public AudioClip coinSound;

    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject coinController = GameObject.FindWithTag("CoinTracker");

        if (collision.gameObject.tag == "Player")
        {
            CoinTracker tracker = coinController.GetComponent<CoinTracker>();
            tracker.totalCoins += coin;
            Destroy(gameObject);
            source.PlayOneShot(coinSound);
        }
    }
}
