﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundParticleDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Example());

    }

    IEnumerator Example()
    {
        print(Time.time);
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
