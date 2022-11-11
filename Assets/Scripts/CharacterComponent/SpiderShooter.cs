using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class SpiderShooter : MonoBehaviour
{
    [Header("ShootSetting")]
    public Transform shootPoint;
    public float maxDistance;
    public LayerMask layerMask;

    [Header("Grabbing")]
    private Vector3 grabbingPoint;
    private Vector3 currentGrabbingPoint;
    private Transform grabableObject;

    [Header("Line Renderer")]
    private LineRenderer spiderLine;
    public Camera cameraMain;
    public Transform Mouth;
    public GameObject playerCharacter;

    private CharacterController characterController;
    private ThirdPersonController thirdcontroller;

    // Start is called before the first frame update
    void Start()
    {
        spiderLine = GetComponent<LineRenderer>(); //get access to LineRenderer
        spiderLine.enabled = false;
        characterController = playerCharacter.GetComponentInChildren<CharacterController>();
        thirdcontroller= playerCharacter.GetComponentInChildren<ThirdPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            StartGrabbing();
        }
        else 
        {
            EndGrabbing();
        }

    }

    public void StartGrabbing()  //start grapple method
    {
        Ray ray = cameraMain.ScreenPointToRay(Input.mousePosition);  

        RaycastHit hitInfo;
        bool hit = Physics.Raycast(ray, out hitInfo, maxDistance, layerMask);

        if (hit)
        {
            grabbingPoint = hitInfo.point;      //save the transform where i grappleed

            //spiderLine.SetPosition(1, swingPoint);
            //Mouth.LookAt(hitInfo.point);

            
            //currentGrabbingPoint = shootPoint.position;
            //currentGrabbingPoint = Vector3.Lerp(currentGrabbingPoint, grabbingPoint, Time.deltaTime * 8f);

            spiderLine.SetPosition(0, shootPoint.position);
            spiderLine.SetPosition(1, hitInfo.point);

            if (hitInfo.collider.gameObject.tag=="Grabable")
            {
                //Debug.Log("I grab it!");
                grabableObject = hitInfo.collider.transform;
                // grabableObject.position = Vector3.Lerp(grabableObject.position, shootPoint.position, Time.deltaTime);

                Debug.Log(grabableObject);

                thirdcontroller.Gravity = 0;

                Vector3 direction = characterController.transform.position - grabableObject.position;
                direction = -direction.normalized;
                characterController.Move(direction*Time.deltaTime*0.5f);

                    // playerCharacter.transform.position = Vector3.Lerp(playerCharacter.transform.position, grabableObject.position, Time.deltaTime);
                //Debug.Log(playerCharacter.transform.position);


            }


            //Debug.Log("Hit the hangable");    //probably let it hit something else later
            //Debug.DrawLine(shootPoint.position, hitInfo.point, Color.red);

        }
        else
        {
            spiderLine.SetPosition(0, shootPoint.position);
            spiderLine.SetPosition(1, shootPoint.position + ray.direction * maxDistance);
        }

        spiderLine.enabled = true;
    }

    public void EndGrabbing()
    {
        spiderLine.enabled = false;

        //thirdcontroller.Gravity = -15;

        grabableObject =null;
    }

}
