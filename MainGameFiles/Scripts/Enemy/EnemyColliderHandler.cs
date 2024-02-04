using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColliderHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Close to the player");
        }
    }
}
