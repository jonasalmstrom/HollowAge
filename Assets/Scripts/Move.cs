using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    //Change how many times one can jump//
    public int Jump = 1;
    //How fast one runs//
    public float moveSpeed = 5;
    //How high one jumps//
    public float jumpSpeed = 11;
    public float DashTime = 0f;
    public float DashSpeed = 2f;
    public float DashStopp = 1f;
    public float Cooldown = 2;
    public bool Dash = true;
    public bool JumpB;
    public float JumpCooldown = 1.1f;
    public GroundChecker groundChecker;


    //The body one wish to move when one inputs a directional button//
    private Rigidbody2D rbody;

    //Sets the body one can move//
    private void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    //Movement left<->right and the jump button//
    void Update()
    {
        rbody.velocity = new Vector2
           (Input.GetAxisRaw("Horizontal") * moveSpeed,
            rbody.velocity.y);

        if (Input.GetButton("Jump"))
        {
            if (Jump <= 1)
            {
            JumpB = true;
            }
            JumpCooldown -= 0.06f;
        }
        if (JumpB == true && JumpCooldown >= 0.125f)
        {
            rbody.velocity = new Vector2
                (rbody.velocity.x, jumpSpeed);
        }
        if (Input.GetButtonUp("Jump"))
        {
            JumpB = false;
        }
        DashMove();
        JumpAmount();
    }
    void DashMove()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && Dash == true)
        {
            DashTime = 0.0f;
            Dash = false;
        }
        else if (DashTime <= DashStopp)
        {
            rbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed * DashSpeed, 1f);
            DashTime += 0.1f;
        }
        else if (DashTime >= DashStopp)
        {
            Cooldown -= Time.deltaTime;
            DashSpeed = 4f;
        }
        if (Cooldown <= 0 && Dash == false)
        {
            Dash = true;
            Cooldown = 2;
        }
    }
    void JumpAmount()
    {
        if (groundChecker.isGrounded == true)
        {
          Jump = 1;
            JumpCooldown = 1f;
        }
        if (Input.GetButtonDown("Jump"))
        {
            Jump = Jump-1;
        }  
    }
} 
