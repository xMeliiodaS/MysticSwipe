using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDetection : MonoBehaviour
{

    [SerializeField] private Transform player;
    [SerializeField] private Transform enemy;
    [SerializeField] private float detectionRange = 2f; // Adjust the range as needed


    void Update()
    {
        // Check if the player is close enough
        if (IsPlayerClose())
        {
            // Perform actions when the player is close
            Debug.Log("Player is close!");
        }
    }


    /// <summary>
    /// Check if the player is close enough
    /// </summary>
    /// <returns></returns>
    private bool IsPlayerClose()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            return distanceToPlayer <= detectionRange;
        }

        return false;
    }
}
