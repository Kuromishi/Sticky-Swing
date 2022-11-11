using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWayPoint : MonoBehaviour
{
    private float searchRadius = 0.5f;

    private void OnDrawGizmos()
    {
        for (var i = 0; i < transform.childCount; i++)
        {
            Gizmos.DrawSphere(GetWaypointPosition(i), searchRadius);
            Gizmos.DrawLine(GetWaypointPosition(i), GetWaypointPosition(GetNextWaypointIndex(i)));
        }
    }

    public int GetNextWaypointIndex(int i)
    {
        var nextIndex = i == transform.childCount - 1 ? 0 : i + 1;
        return nextIndex;
    }

    public Vector3 GetWaypointPosition(int i)
    {
        return transform.GetChild(i).position;
    }
}
