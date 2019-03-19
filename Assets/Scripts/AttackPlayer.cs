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
    // Start is called before the first frame update
    void Start()
    {
        playerAttackObject = GameObject.FindGameObjectsWithTag("Weapon");
        HideSwordOnAttack();
        Anime = GetComponent<Animator>();
        Swing = 1;
        groundChecker = GetComponentInChildren<GroundChecker>();
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
        else
            HideSwordOnAttack();
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            Swing = 1;
        }
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
}
