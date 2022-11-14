using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenButtonDetect : MonoBehaviour
{
    public bool greenKey = false;

    AudioSource greenKeyAudio;
    public AudioClip greenKeyClip;

    void Start()
    {
        greenKeyAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Absorbable") && other.GetComponent<GreenKey>() != null)  //if the gameobject is absorbable and the green key is in the trigger
        {
            greenKey = true;   // you got the green key
            greenKeyAudio.clip = greenKeyClip;
            greenKeyAudio.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Absorbable") && other.GetComponent<GreenKey>() != null)  //remove the green key
        {
            greenKey = false;
        }
    }
}
