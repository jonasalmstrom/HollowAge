using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class attack : MonoBehaviour
{
    public Animator attack1;
    public SpriteRenderer this1;
    private void Start()
    {
        this1 = GetComponent<SpriteRenderer>();
        attack1 = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            this1 = true;
            attack1.SetTrigger("Attack");
        }
        else
        {
            attack1.ResetTrigger("Attack");

        }

    }
}
