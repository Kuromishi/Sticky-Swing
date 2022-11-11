using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButtonDetect : MonoBehaviour
{
    public bool redKey = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Grabable") && other.GetComponent<RedKey>()!=null)
        {
            redKey = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Grabable") && other.GetComponent<RedKey>() != null)
        {
            redKey = false;
        }
    }
}
