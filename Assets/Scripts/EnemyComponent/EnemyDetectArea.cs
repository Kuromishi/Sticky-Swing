using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectArea : MonoBehaviour
{
    private EnemyController enemyController;

    private void Start()
    {
        enemyController = GetComponentInParent<EnemyController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var playerCharacter = other.GetComponent<SpiderShooter>();

        if (playerCharacter)
        {
            Debug.Log("Found!");
            enemyController.FindPlayer(playerCharacter);
            Destroy(gameObject);

        }
    }
}
