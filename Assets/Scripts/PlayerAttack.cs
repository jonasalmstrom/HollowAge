using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    GameObject[] playerAttackObject;

    // Start is called before the first frame update
    void Start()
    {
        playerAttackObject = GameObject.FindGameObjectsWithTag("Weapon");
        HideSwordOnAttack();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Mouse0) || (Input.GetKey(KeyCode.LeftControl)))
        {
            print("Hit!");
            ShowSwordOnAttack();
        }
        else
            HideSwordOnAttack();

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
