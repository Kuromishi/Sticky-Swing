using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public EndTransit endTrigger;

    //Reference: The use of Audio Source and Audio Clips
    //https://www.bilibili.com/video/BV197411D735/?spm_id_from=333.1007.top_right_bar_window_history.content.click

    AudioSource deathZoneAudio;
    public AudioClip deathZoneClip;

    void Start()
    {
        deathZoneAudio = GetComponent<AudioSource>();   // get the access to Audio Source
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            deathZoneAudio.clip = deathZoneClip;   //play the death audio
            deathZoneAudio.Play();


            endTrigger.LoseGame();  // get the LoseGame Method in endTrigger Class


        }
    }
}
