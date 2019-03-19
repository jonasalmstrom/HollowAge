using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    //The bool thet is checked to detirmen if one shall be able to jump//
    public bool isGrounded;

    //If the player is grounded than set isGrounded to true//
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
    }

    //If the player is not grounded than set isGrounded to false//
    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded  = false;
    }







}
