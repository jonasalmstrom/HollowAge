using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundParticleDestroy : MonoBehaviour
{
    public float timeTilDestroy;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Example());

    }

    IEnumerator Example()
    {
       
        yield return new WaitForSeconds(timeTilDestroy);
        Destroy(gameObject);
    }
}
