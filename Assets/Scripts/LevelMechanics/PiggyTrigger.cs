using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PiggyTrigger : MonoBehaviour
{
    public EndTransit endTrigger;
    public int piggyNum = 0;


    AudioSource piggyWinAudio;
    public AudioClip piggyWinClip;


    private void Start()
    {
        piggyWinAudio = GetComponent<AudioSource>();
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
            piggyWinAudio.clip = piggyWinClip;
            piggyWinAudio.Play();
            endTrigger.WinGame();
        }
    }
}
