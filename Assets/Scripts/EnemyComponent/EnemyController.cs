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
    private bool isChasingPlayer;
    private bool isRotating;

    private Vector3 targetPos;
    private Transform targetTransform;
    private SpiderShooter targetPlayer;

    private int waypointIndex = 0;

    private void Start()
    {
        StartCoroutine(RotateToTarget());
    }

    private void Update()
    {

        if (isChasingPlayer && !isRotating)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, chaseSpeed * Time.deltaTime);

            if (Mathf.Abs(Vector3.Distance(transform.position, targetPos)) <= 0.5f)
            {
                targetPos = targetTransform.position;
                targetPos += (targetPos - transform.position).normalized;

                StartCoroutine(RotateToTarget());
                // transform.LookAt(targetPos);
            }
        }

        if (!isChasingPlayer && !isRotating)
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


    public void FindPlayer(SpiderShooter playerCharacter)
    {
        targetPlayer = playerCharacter;
        targetTransform = playerCharacter.transform;
        targetPos = targetTransform.position;
        targetPos += (targetPos - transform.position).normalized;
        isChasingPlayer = true;
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
