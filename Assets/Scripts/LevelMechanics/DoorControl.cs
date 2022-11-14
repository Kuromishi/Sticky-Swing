using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{

    private Animator anim_door;

    AudioSource doorOpened;
    public AudioClip doorOpenedClip;

    [Header("KeyDetect")]
    public RedButtonDetect redKeyDetect;     // To get the three class, because i should use the xxxkey boolean value
    public BlueButtonDetect blueKeyDetect;
    public GreenButtonDetect greenKeyDetect;

    private void Start()
    {
        anim_door = GetComponent<Animator>();

        doorOpened = GetComponent<AudioSource>();
    }

    private void Update()
    {   
        if (redKeyDetect.redKey && blueKeyDetect.blueKey && greenKeyDetect.greenKey)  //when you get the three keys
        {
            //Debug.Log("Door is opened");
            anim_door.SetBool("Opened", true);   //play the open the door animation

            doorOpened.clip = doorOpenedClip;
            doorOpened.Play();
        }
    }



}
