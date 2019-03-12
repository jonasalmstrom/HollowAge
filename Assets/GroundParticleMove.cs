using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundParticleMove : MonoBehaviour
{
    public ParticleSystem groundMoveParticle;


    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            if(Input.GetKeyDown(KeyCode.A))
            {
                Instantiate(groundMoveParticle, transform.position, groundMoveParticle.transform.rotation);
            }
        }
    }
}
