using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collectCoinScript : MonoBehaviour
{

    public ParticleSystem coinPickupLightParticle;
    public ParticleSystem coinPickupParticle;
    public float coin = 1;
    public AudioClip coinSound;
    public Slider coinSlider;
    
    private AudioSource source;
   
    public Transform cam;
    private void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject coinController = GameObject.FindWithTag("CoinTracker");

        if (collision.gameObject.tag == "Player")
        {
            source.PlayOneShot(coinSound);
            Instantiate(coinPickupParticle, transform.position, coinPickupParticle.transform.rotation);
            Instantiate(coinPickupLightParticle, transform.position, coinPickupLightParticle.transform.rotation);
            AudioSource.PlayClipAtPoint(coinSound, cam.transform.position);
            Destroy(gameObject);
        }
    }
}
