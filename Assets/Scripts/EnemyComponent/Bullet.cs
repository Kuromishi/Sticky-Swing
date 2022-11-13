using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;

    public float bulletSpeed;
    public float bulletForce;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * bulletSpeed;
    }

    private void Update()
    {
        rb.AddForce(Vector3.right * bulletForce, ForceMode.Impulse);
        Destroy(gameObject,100);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerLogic>() != null)
        {

            //Debug.Log("Bullet hit me!");
           
            //Play an audio
            //don't know why the script won't appear in the perfabs, so wanna just let it be a barrier here. 


        }
        Destroy(gameObject);
    }

}
