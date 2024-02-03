using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;

    [SerializeField] private Transform player;
    [SerializeField] private float detectionRange = 2f; // Adjust the range as needed


    void Start()
    {
        currentHealth = maxHealth;
    }


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
