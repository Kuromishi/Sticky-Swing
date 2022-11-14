using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectArea : MonoBehaviour
{
    public EndTransit endTrigger;


    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            //Debug.Log("Found!");

            endTrigger.LoseGame();
        }
    }
}
