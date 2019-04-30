using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectCoinScript : MonoBehaviour
{

    public ParticleSystem coinPickupLightParticle;
    public ParticleSystem coinPickupParticle;
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
            Instantiate(coinPickupParticle, transform.position, coinPickupParticle.transform.rotation);
            Instantiate(coinPickupLightParticle, transform.position, coinPickupLightParticle.transform.rotation);
            CoinTracker tracker = coinController.GetComponent<CoinTracker>();
            tracker.totalCoins += coin;
            Destroy(gameObject);
            source.PlayOneShot(coinSound);
        }
    }
}
