using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class MoveNew : MonoBehaviour
{
    public float moveSpeed;
    public float maxSpeed;
    public float highJumpForce;
    public float lowJumpForce;
    public float dashCooldown;
    public float nextDash;
    public float dashForce;
    public GroundChecker groundChecker;
    public float jumpTime;
    public bool lookright = false;
    public Animator anim;
    public float fallMultiplier;

    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;


    private float moveInput;
    private Rigidbody2D rb;
    private bool isGrounded;
    private float jumpTimeCounter;
    public bool isJumping;
    private bool allowJump;
    private bool allowHighJump;
    private bool allowDash;
    private bool jum;
    public bool isDashing = false;

    private void Awake()
    {
        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        if (moveInput != 0)
        {
            rb.AddForce(new Vector2(moveInput * moveSpeed, 0), ForceMode2D.Impulse);
        }
        else
        {
            rb.velocity -= new Vector2(rb.velocity.x, 0);
        }

        if (rb.velocity.y < 0)
        {
            rb.gravityScale = 5;
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;

        }

        if (rb.velocity.x > maxSpeed)
        {
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
        }

        if (rb.velocity.x < -maxSpeed)
        {
            rb.velocity = new Vector2(-maxSpeed, rb.velocity.y);
        }

        if (groundChecker.isGrounded && jum)
        {
            allowJump = true;
            anim.SetBool("IsJumping", true);
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

        jum = Input.GetKeyDown(KeyCode.Space);



        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            allowHighJump = true;
            


        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
            anim.SetBool("IsJumping", false);
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
                rb.AddForce(Vector2.right * dashForce, ForceMode2D.Impulse);
                anim.SetBool("IsDashing", true);
                isDashing = true;
                allowDash = false;
            }
            else
            {
                rb.AddForce(-Vector2.right * dashForce, ForceMode2D.Impulse);
                anim.SetBool("IsDashing", true);
                allowDash = false;
                isDashing = true;
            }

        }
        else
        {
            anim.SetBool("IsDashing", false);
            isDashing = false;
        }
    }

    public void OnLanding()
    {
        anim.SetBool("IsJumping", false);

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
                anim.SetBool("IsJumping", false);
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
