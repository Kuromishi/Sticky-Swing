using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PiggyTrigger : MonoBehaviour
{
    public EndTransit endTrigger;
    public int piggyNum = 0;



    private void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<piggy>()!=null )
        {
            piggyNum++;
            //Debug.Log(piggyNum);
            
        }
        if(piggyNum == 3)
        {
            endTrigger.GameOver();
        }
    }
}
