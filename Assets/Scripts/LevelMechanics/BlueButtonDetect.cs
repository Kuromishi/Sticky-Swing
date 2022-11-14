using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueButtonDetect : MonoBehaviour
{
    public bool blueKey = false;

    AudioSource blueKeyAudio;
    public AudioClip blueKeyClip;

    void Start()
    {
        blueKeyAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Absorbable") && other.GetComponent<BlueKey>() != null)
        {
            blueKey = true;
            blueKeyAudio.clip = blueKeyClip;
            blueKeyAudio.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Absorbable") && other.GetComponent<BlueKey>() != null)
        {
            blueKey = false;
        }
    }
}
