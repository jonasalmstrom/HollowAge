using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundParticle : MonoBehaviour
{
    public ParticleSystem groundParticle;

    public Animator anim;

    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Instantiate(groundParticle, transform.position, groundParticle.transform.rotation);
            anim.SetTrigger("Shake");
        }
    }



}
