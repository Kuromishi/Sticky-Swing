using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    CharacterController characterController;

    [Header("Player Movement")]
    public float movementSpeed;

    private float horizontalInput;
    private float verticalInput;

    Vector3 verticalMovement;
    Vector3 horizontalMovement;

    GameObject camera;
    CameraLogic cameraLogic;


    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        camera = Camera.main.gameObject;
        if(camera)
        {
            cameraLogic = camera.GetComponent<CameraLogic>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");


    }

    private void FixedUpdate()
    {
        if(cameraLogic && (Mathf.Abs(horizontalInput)>0.1f || Mathf.Abs(verticalInput) > 0.1f))
        {
            transform.forward = cameraLogic.GetForwardVector();
        }

        verticalMovement = transform.forward * verticalInput * movementSpeed * Time.deltaTime;
        horizontalMovement = transform.right * horizontalInput * movementSpeed * Time.deltaTime;

        characterController.Move(horizontalMovement + verticalMovement);
    }
}
