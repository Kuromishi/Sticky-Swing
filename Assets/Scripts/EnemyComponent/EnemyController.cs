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

        if (!isRotating) //If it's not rotating. The emeny will rotate only when it gets the waypoint
        {
            if (targetPos != enemyWaypoint.GetWaypointPosition(waypointIndex))
            {
                StartCoroutine(RotateToTarget());  // get to the waypoint
            }

            targetPos = enemyWaypoint.GetWaypointPosition(waypointIndex);
            transform.position = Vector3.MoveTowards(transform.position, targetPos, patrolSpeed * Time.deltaTime);


            if (Mathf.Abs(Vector3.Distance(transform.position, targetPos)) <= 0.5f)
            {
                waypointIndex = enemyWaypoint.GetNextWaypointIndex(waypointIndex);   //get next point
            }
            // else
            // {
            //     transform.LookAt(targetPos);
            // }
        }
    }

    //Reference:Detailed explanation of principle and usage of Coroutine
    //https://blog.csdn.net/xinzhilinger/article/details/116240688

    private IEnumerator RotateToTarget()   //Coroutines
    {
        isRotating = true;
        var t = 0f;
        while (t <= 1f)
        {
            t += Time.deltaTime;

            //calculate the cosine degree of the two vectors
            if (Vector3.Dot(targetPos - transform.position, -transform.right) <= 0)
            {
                transform.Rotate(0, 180f * Time.deltaTime, 0);    //make the enemy rotate
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
