using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public GameObject playerObject;
    public float teleportPositionX;
    public float teleportPositionY;

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerObject.transform.position = new Vector2(teleportPositionX, teleportPositionY);
        }
    }
}
