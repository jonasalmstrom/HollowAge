using UnityEngine;
using System.Collections;

public class CheckPointScript : MonoBehaviour
{
    private GameMaster gm;


    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            animator.SetBool("checkPointactive", true);
            Debug.Log("Yas");
            gm.lastCheckPointPos = transform.position;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            animator.SetBool("checkPointactive", false);
    }
}
