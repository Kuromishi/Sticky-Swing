using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryLogic : MonoBehaviour
{
    [Header("Shooting")]
    public Bullet bulletPrefab;
    public Transform bulletPoint;

    [Header("Timer")]
    public float reloadTimer;
    public float reloadTime;  //set the reloadTime to 2 -> shoot the bullet every 2 seconds

    private void Update()
    {
        reloadTimer -= Time.deltaTime;  

        if (reloadTimer > 0) return;    //if the reload time hasn't become 0, then don't execute the codes below

        
        Instantiate(bulletPrefab, bulletPoint.position, bulletPoint.rotation); //instantiate the bullet
        reloadTimer = reloadTime;  // reset the reload time
    }
}
