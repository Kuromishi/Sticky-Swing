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
        if (collision.gameObject.GetComponent<PlayerDetect>() != null)
        {

            //Debug.Log("Bullet hit me!");
            
        }
        Destroy(gameObject);
    }
}
