using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveNew : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed;
    private float moveInput;
    public float highJumpForce;
    public float lowJumpForce;

    private bool isGrounded;
    public GroundChecker groundChecker;
    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;
    private bool allowJump;
    private bool allowHighJump;
    private bool allowDash;

    public float dashCooldown;
    public float nextDash;

    public float dashForce;


    public bool lookright = false;
    public Animator anim;
    public float fallMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if (rb.velocity.y < 0)
        {
            rb.gravityScale = 5;
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;

        }

        Jumps();
        DashMove();
    }

    private void Update()
    {
        nextDash += Time.deltaTime;

        anim.SetFloat("Speed", Mathf.Abs(moveInput));

        if (Input.GetKeyDown(KeyCode.D) && lookright == false)
        {
            Flip();


        }

        if (Input.GetKeyDown(KeyCode.A) && lookright == true)
        {
            Flip();

        }

        if (groundChecker.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            allowJump = true;
        }

        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            allowHighJump = true;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && nextDash >= dashCooldown)
        {
            allowDash = true;
            nextDash = 0;

        }
    }

    void DashMove()
    {
        if (allowDash)
        {
            if (lookright)
            {
                rb.velocity += Vector2.right * dashForce * Time.deltaTime;
                allowDash = false;
            }
            else
            {
                rb.velocity += -Vector2.right * dashForce * Time.deltaTime;
                allowDash = false;
            }

        }
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        lookright = !lookright;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void Jumps()
    {
        if (allowHighJump)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity += Vector2.up * highJumpForce * Time.deltaTime;
                jumpTimeCounter -= Time.deltaTime;

            }
            else
            {
                isJumping = false;
            }
            if (jumpTimeCounter <= 0)
            {
                rb.gravityScale = 2.5f;
            }
            allowHighJump = false;
        }
        if (allowJump)
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity += Vector2.up * lowJumpForce * Time.deltaTime;
            allowJump = false;
        }
    }
}
