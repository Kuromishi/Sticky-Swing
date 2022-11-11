using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{

    private Animator anim_door;

    public RedButtonDetect redKeyDetect;
    public BlueButtonDetect blueKeyDetect;
    public GreenButtonDetect greenKeyDetect;

    private void Start()
    {
        anim_door = GetComponent<Animator>();
        
    }

    private void Update()
    {
        
        if (redKeyDetect.redKey && blueKeyDetect.blueKey && greenKeyDetect.greenKey)
        {
            //Debug.Log("Door is opened");
            anim_door.SetBool("Opened", true);   //play the open the door animation

        }
    }



}
