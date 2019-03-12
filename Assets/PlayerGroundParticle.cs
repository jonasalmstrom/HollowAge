using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundParticle : MonoBehaviour
{
    public ParticleSystem groundParticle;


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Ground")
        {
            Instantiate(groundParticle);

        }
    }
}
