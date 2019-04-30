using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public GameObject[] playerAttackObject;
    public GameObject attackSide;
    public GameObject attackUp;
    public GameObject attackDown;

    // Start is called before the first frame update
    void Start()
    {
        playerAttackObject = GameObject.FindGameObjectsWithTag("Weapon");
        HideSwordOnAttack();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyUp(KeyCode.L) && Input.GetKey(KeyCode.S))
        {
            ShowSwordOnAttackDown();
        }
        else if (Input.GetKeyUp(KeyCode.L) && Input.GetKey(KeyCode.W))
        {
            ShowSwordOnAttackUp();
        }
        else if (Input.GetKeyUp(KeyCode.L))
        {
            ShowSwordOnAttackSide();
        }
        else
            HideSwordOnAttack();
    }

    public void ShowSwordOnAttackSide()
    {
        attackSide.SetActive(true);
    }

    public void ShowSwordOnAttackUp()
    {
        attackUp.SetActive(true);
    }

    public void ShowSwordOnAttackDown()
    {
        attackDown.SetActive(true);
    }

    public void HideSwordOnAttack()
    {
        foreach (GameObject g in playerAttackObject)
        {
            g.SetActive(false);
        }
    }
}
