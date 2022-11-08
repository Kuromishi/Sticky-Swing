using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDetect : MonoBehaviour
{
    private bool gotRedKey = false;
    private bool gotYellowKey = false;
    private bool gotBlueKey = false;

    public GameObject door;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RedKey"))
        {
            gotRedKey = true;
        }
    }
}
