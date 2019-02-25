using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public int touches;
    //om objektet kolliderar med en annan collider så ändras värdet på variabeln "touches" med +1 (en trigger)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        touches++;
    }
    //om objektet sedan lämnar den kollisionen alltså "exitar" så ändras värdet på variabeln med -1 (ken trigger)
    private void OnTriggerExit2D(Collider2D collision)
    {
        touches--;
    }
}
