using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundLeave : MonoBehaviour
{
    public ParticleSystem groundParticleLeave;

    public void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Instantiate(groundParticleLeave, transform.position, groundParticleLeave.transform.rotation);
        }
    }
}
