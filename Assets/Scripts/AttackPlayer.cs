using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class AttackPlayer : MonoBehaviour
{
    GameObject[] playerAttackObject;
    public Animator Anime;
    public int Swing;
    public GroundChecker groundChecker;
    public Rigidbody2D rbody;
    // Start is called before the first frame update
    void Start()
    {
        playerAttackObject = GameObject.FindGameObjectsWithTag("Weapon");
        HideSwordOnAttack();
        Anime = GetComponent<Animator>();
        Swing = 1;
        groundChecker = GetComponentInChildren<GroundChecker>();
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.LeftControl)&&Swing==1&&groundChecker.isGrounded==true)
        {
            print("Hit!");
            ShowSwordOnAttack();
            Anime.SetTrigger("Attack");
            Swing -= 1;
            Anime.SetTrigger("AttackExit");
        }
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.S) && Swing == 1&&groundChecker.isGrounded==false)
        {
            print("HitDow");
            ShowSwordOnAttack();
            Anime.SetTrigger("AttackAirDir");
            Swing -= 1;
            Anime.SetTrigger("AttackExit");
        }
        if (Input.GetKey(KeyCode.LeftControl) && Swing == 1 && groundChecker.isGrounded == false)
        {
            print("AirHit");
            ShowSwordOnAttack();
            Anime.SetTrigger("AttackAir");
            Swing -= 1;
            Anime.SetTrigger("AttackExit");
        }
        
                
            
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            Swing = 1;
            HideSwordOnAttack();
        }
        Animation();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
    }

    public void ShowSwordOnAttack()
    {
        foreach (GameObject g in playerAttackObject)
        {
            g.SetActive(true);
        }
    }

    public void HideSwordOnAttack()
    {
        foreach (GameObject g in playerAttackObject)
        {
            g.SetActive(false);
        }
    }
    void Animation()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Anime.SetTrigger("Jump");
            Anime.ResetTrigger("JumpLand");
        }
        if (Input.GetKeyUp(KeyCode.Space) || rbody.velocity.y <= -0.1f)
        {
            Anime.SetTrigger("JumpPeak");
            Anime.ResetTrigger("JumpLand");
            Anime.ResetTrigger("Jump");
        }
        if (rbody.velocity.y == 0)
        {
            Anime.SetTrigger("JumpLand");
            Anime.ResetTrigger("JumpPeak");
        }
        if (rbody.velocity.x >= 0 || rbody.velocity.x <= 0)
        {
            Anime.SetBool("Walk", true);
        }
        if (rbody.velocity.x == 0)
        {
            Anime.SetBool("Walk", false);
        }
        if (Move.dash == true)
        {
            Anime.SetBool("Dash", true);
        }
        if (Move.dash == false)
        {
            Anime.SetBool("Dash", false);
        }
    }
}
