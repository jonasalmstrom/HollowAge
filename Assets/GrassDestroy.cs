using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassDestroy : MonoBehaviour
{
    public ParticleSystem grassDestroy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            Instantiate(grassDestroy, transform.position, grassDestroy.transform.rotation);

            Destroy(gameObject);
        }
    }
}
