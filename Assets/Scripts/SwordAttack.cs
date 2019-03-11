using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{

    GameObject[] playerAttackObject;

    // Start is called before the first frame update
    void Start()
    {
        playerAttackObject = GameObject.FindGameObjectsWithTag("Weapon");
        HideSwordOnAttack();
    }

    private void FixedUpdate()
    {
        print("1");

        if (Input.GetKey(KeyCode.C))
        {
            print("Hit!");
            ShowSwordOnAttack();
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
