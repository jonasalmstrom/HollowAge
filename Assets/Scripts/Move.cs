using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
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
    public float move;
    public bool Right;
    public float Flip;
    private Vector3 Fliper;
    public static bool dash;
    //The body one wish to move when one inputs a directional button//
    private Rigidbody2D rbody;

    //Sets the body one can move//
    private void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        Flip = 1;
        Fliper.x = Flip;
        Fliper.y = 1;
        Fliper.z = 1;
    }

    //Movement left<->right and the jump button//
    void Update()
    {
        move = (Input.GetAxisRaw("Horizontal") * moveSpeed);
        if (Mathf.Abs(move)>= 0f)
        {
            rbody.velocity = new Vector2(move,
            rbody.velocity.y);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Right = false;
            Flip = -1;
            Fliper.x=Flip;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Right = true;
            Flip = 1;
            Fliper.x = Flip;
        }
        if (Right == false)
        {
            transform.localScale = Fliper ;
        }
        if (Right == true)
        {
            transform.localScale = Fliper;
        } 
        if (Input.GetButton("Jump"))
        {
            if (Jump == 1)
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
            dash = true;
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
        if (groundChecker.isGrounded==true && Dash == true)
        {
            dash = false;
        }
    }
    void JumpAmount()
    {if (JumpB == false && groundChecker.isGrounded == true)
        {
            JumpCooldown = 1f;
        }
        if (groundChecker.isGrounded == true)
        {
            Jump = 1;
        }
        if (Input.GetButtonDown("Jump"))
        {
            Jump = Jump - 1;
        }
    }
}
