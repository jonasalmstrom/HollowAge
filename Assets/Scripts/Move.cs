using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    //Change how many times one can jump//
    //public int JumpCount = 1;
    //How fast one runs//
    public float moveSpeed = 5;
    //How high one jumps//
   // public float jumpSpeed = 11;
    public float DashTime = 0f;
    public float DashSpeed = 2f;
    public float DashStopp = 1f;
    public float DashCooldown = 2;
    public bool Dash = true;
    //public bool JumpB;
    //public float JumpCooldown = 1.1f;
    //public float JumpHoldTime = 0.5f;
    //  private float JumpHoldingTime;
    public GroundChecker groundChecker;
    public GameObject player;

    public bool lookright = false;
    public float move = 0f;
    //The body one wish to move when one inputs a directional button//
    private Rigidbody2D rbody;

    private Animator anim;

    //Sets the body one can move//
    private void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        move = Input.GetAxisRaw("Horizontal") * moveSpeed;

        rbody.velocity = new Vector2(moveSpeed, rbody.velocity.x);

    }

    //Movement left<->right and the jump button//
    void Update()
    {

        anim.SetFloat("Speed", Mathf.Abs(move));

        if (Input.GetKeyDown(KeyCode.D) && lookright == false)
        {
            Flip();


        }

        if (Input.GetKeyDown(KeyCode.A) && lookright == true)
        {
            Flip();

        }

        //TODO: Fixa jump.

        //JumpCooldown -= Time.deltaTime;
        //if (Input.GetButtonDown("Jump"))
        //{
        //    if (JumpCount > 0)
        //    {
        //        JumpB = true;
        //        JumpCount--;
        //    }

        //}

        //if (Input.GetButton("Jump"))
        //{
        //    if (JumpB && JumpHoldingTime <= JumpHoldTime)
        //    {
        //        rbody.velocity = new Vector2
        //            (rbody.velocity.y, jumpSpeed);
        //        JumpHoldingTime += Time.deltaTime;
        //    }
        //}
        //if (Input.GetButtonUp("Jump"))
        //{
        //    JumpB = false;
        //    JumpCooldown = 1f;
        //    JumpHoldingTime = 0f;
        //}
        DashMove();
        //JumpAmount();
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
            DashTime += 0.1f * Time.deltaTime;
        }
        else if (DashTime >= DashStopp)
        {
            DashCooldown -= Time.deltaTime;
            DashSpeed = 4f;
        }
        if (DashCooldown <= 0 && Dash == false)
        {
            Dash = true;
            DashCooldown = 2;
        }
    }
    //void JumpAmount()
    //{
    //    if (groundChecker.isGrounded == true)
    //    {
    //        JumpCount = 1;
    //    }
    //}

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        lookright = !lookright;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
