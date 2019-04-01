using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundParticleMove : MonoBehaviour
{
    public ParticleSystem groundMoveParticle;


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.A))
            {
                Instantiate(groundMoveParticle, transform.position, groundMoveParticle.transform.rotation);

            }
            
            if(Input.GetKey(KeyCode.D))
            {
                Instantiate(groundMoveParticle, transform.position, groundMoveParticle.transform.rotation);
            }

        }
    }
}
