using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassDestroy : MonoBehaviour
{
    public AudioClip grass;
    private AudioSource source;
    public ParticleSystem grassDestroy;
    public Transform cam;
    
    //public float destroyWaitTime;
    // Start is called before the first frame update
    void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            Instantiate(grassDestroy, transform.position, grassDestroy.transform.rotation);
            AudioSource.PlayClipAtPoint(grass, cam.transform.position);
            Destroy(gameObject);
        }
    }

}
