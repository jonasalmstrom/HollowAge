using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    [Range(0, 50)]
    public float moveSpeed;
    public float jumpHeight;
    //här accessar den det andra scriptet "GroundCheck" och tar värdet på variabeln därifrån
    public GroundCheck groundCheck;

    // Use this for initialization
    void Start()
    {
        //hittar en komponent och länkar den till "rb"
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //den horisontella velocityn på rigidbodyn är beroende på moveSpeed, den vertikala är den samma
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y);
        //om man trycker på W och groundcheck.touches värdet är över noll(rör mer än noll) så kan man hoppa
        if (Input.GetKeyDown(KeyCode.W) && groundCheck.touches > 0)
        {
            //rigidbodyn får då samma velocity i x led som ovan men den får "jumpHeight" i y led
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }
    }
}
