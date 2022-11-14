using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButtonDetect : MonoBehaviour
{
    public bool redKey = false;

    AudioSource redKeyAudio;
    public AudioClip redKeyClip;

    void Start()
    {
        redKeyAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Absorbable") && other.GetComponent<RedKey>()!=null)
        {
            redKey = true;
            redKeyAudio.clip = redKeyClip;
            redKeyAudio.Play();

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Absorbable") && other.GetComponent<RedKey>() != null)
        {
            redKey = false;
        }
    }
}
