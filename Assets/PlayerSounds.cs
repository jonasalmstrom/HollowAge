using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    public AudioClip jump;
    public AudioClip running;
    public AudioClip dash;
    public float frash;
    public bool step;

    private AudioSource source;
    private MoveNew mw;
    private GroundChecker gc;
    private bool canJump;

    private void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
        mw = gameObject.GetComponent<MoveNew>();
        gc = gameObject.GetComponentInChildren<GroundChecker>();
   
    }

    private void Update()
    {
        if (mw.isJumping == true && canJump == true)
        {
            source.PlayOneShot(jump);
            canJump = false;
        }
        if (mw.isJumping == false)
            canJump = true;

        if (Input.GetKey(KeyCode.A) && step == true || Input.GetKey(KeyCode.D) && step == true)
        {
            print("wwww");
            if (gc.isGrounded == true)
            {
                print("eeee");
                if (canJump == false)
                {
                    source.PlayOneShot(running);
                    step = false;
                    Invoke("StepTrue", frash);
                    print("yyy");
                }

            }
        }


        if (mw.isDashing == true)
        {
            source.PlayOneShot(dash);

        }
    }

    void StepTrue()
    {
        step = true;
    }
}
