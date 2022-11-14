using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    CharacterController characterController;

    [Header("Player Movement")]
    public float movementSpeed;

    private float horizontalInput;
    private float verticalInput;
    Vector3 movementInput;

    Vector3 verticalMovement;
    Vector3 horizontalMovement;
    private Vector3 processedInput;

    public GameObject cameraObject;
    CameraLogic cameraLogic;

    private Rigidbody rigidBody;


    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        //cameraObject = Camera.main.gameObject;
        if (cameraObject)
        {
            cameraLogic = cameraObject.GetComponent<CameraLogic>();
        }
    }

    void Update()
    {
        //move the transform
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        movementInput = new Vector3(horizontalInput, 0, verticalInput);
        processedInput = transform.right * horizontalInput + transform.forward * verticalInput;

    }

    private void FixedUpdate()
    {
        if (cameraLogic && (Mathf.Abs(horizontalInput) > 0.1f || Mathf.Abs(verticalInput) > 0.1f))
        {
            transform.forward = cameraLogic.GetForwardVector();
        }

        verticalMovement = transform.forward * verticalInput * movementSpeed * Time.deltaTime;
        horizontalMovement = transform.right * horizontalInput * movementSpeed * Time.deltaTime;

        rigidBody.MovePosition(transform.position + (processedInput * movementSpeed * Time.fixedDeltaTime));

        //characterController.Move(horizontalMovement + verticalMovement);




    }


}
