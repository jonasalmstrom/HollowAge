using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    private GameMaster playerStartPosition;

    private void Start()
    {
        playerStartPosition = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        transform.position = playerStartPosition.lastCheckPointPos;
    }
}
