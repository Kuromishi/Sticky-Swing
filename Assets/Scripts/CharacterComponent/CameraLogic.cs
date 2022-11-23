using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLogic : MonoBehaviour
{
    Vector3 cameraTarget;
    private GameObject playerCharacter;

    private float cameraTargetOffect = 1.5f; //camera height, for the y axis
    private float distanceZ = 6.0f;   //distance in the Z axis away from the player

    private float rotationX;
    private float rotationY;

    const float minRotationX = -5f;
    const float maxRotationX = 2f;


    void Start()
    {
        playerCharacter = GameObject.FindGameObjectWithTag("Player");  //find the player
    }

    void Update()
    {
        cameraTarget = playerCharacter.transform.position;
        cameraTarget.y += cameraTargetOffect; //the height, change in y axis

        if(Input.GetMouseButton(1))
        {
            rotationY += Input.GetAxis("Mouse X");
            rotationX -= Input.GetAxis("Mouse Y"); //up and down
            rotationX = Mathf.Clamp(rotationX, minRotationX, maxRotationX); //limit the camera up and down

        }
    }

    private void LateUpdate()  //after the render is done, want the better effect for camera
    {
        Quaternion cameraRotation = Quaternion.Euler(rotationX, rotationY, 0); 

        Vector3 cameraOffect = new Vector3(0, 0, -distanceZ);
        transform.position = cameraTarget + cameraRotation * cameraOffect; //set the position of the camera

        transform.LookAt(cameraTarget); //make the camera always faces the player
    }

    public Vector3 GetForwardVector()
    {
        Quaternion rotation = Quaternion.Euler(0, rotationY, 0);
        return rotation * Vector3.forward;
    }
}
