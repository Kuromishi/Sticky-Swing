using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueButtonDetect : MonoBehaviour
{
    public bool blueKey = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Grabable") && other.GetComponent<BlueKey>() != null)
        {
            blueKey = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Grabable") && other.GetComponent<BlueKey>() != null)
        {
            blueKey = false;
        }
    }
}
