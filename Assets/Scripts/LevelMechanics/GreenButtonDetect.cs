using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenButtonDetect : MonoBehaviour
{
    public bool greenKey = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Grabable") && other.GetComponent<GreenKey>() != null)
        {
            greenKey = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Grabable") && other.GetComponent<GreenKey>() != null)
        {
            greenKey = false;
        }
    }
}
