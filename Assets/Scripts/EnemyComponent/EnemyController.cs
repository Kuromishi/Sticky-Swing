using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("EnemyMovement")]
    public EnemyWayPoint enemyWaypoint;
    public float patrolSpeed = 2f;
    public float chaseSpeed = 5f;
    public float rotateSpeed = 180f;

    //EnemyState
    private bool isRotating;

    private Vector3 targetPos;

    private int waypointIndex = 0;

    private void Start()
    {
        StartCoroutine(RotateToTarget());
    }

    private void Update()
    {

        if (!isRotating)
        {
            if (targetPos != enemyWaypoint.GetWaypointPosition(waypointIndex))
            {
                StartCoroutine(RotateToTarget());
            }

            targetPos = enemyWaypoint.GetWaypointPosition(waypointIndex);
            transform.position = Vector3.MoveTowards(transform.position, targetPos, patrolSpeed * Time.deltaTime);


            if (Mathf.Abs(Vector3.Distance(transform.position, targetPos)) <= 0.5f)
            {
                waypointIndex = enemyWaypoint.GetNextWaypointIndex(waypointIndex);
            }
            // else
            // {
            //     transform.LookAt(targetPos);
            // }
        }
    }



    private IEnumerator RotateToTarget()   //Coroutines
    {
        isRotating = true;
        var t = 0f;
        while (t <= 1f)
        {
            t += Time.deltaTime;

            if (Vector3.Dot(targetPos - transform.position, -transform.right) <= 0)
            {
                transform.Rotate(0, 180f * Time.deltaTime, 0);
            }
            else
            {
                transform.Rotate(0, -180f * Time.deltaTime, 0);
            }

            yield return null;
        }

        isRotating = false;
        yield return null;
    }
}
