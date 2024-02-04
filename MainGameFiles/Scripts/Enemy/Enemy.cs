using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;

    [SerializeField] private Transform player;
    [SerializeField] private float detectionRange = 2f; // Adjust the range as needed

    // Event to be triggered when the enemy gets close to the player
    public delegate void EnemyCloseToPlayer();
    public event EnemyCloseToPlayer OnEnemyCloseToPlayer;

    void Start()
    {
        currentHealth = maxHealth;

        // Call the distance check when the enemy is spawned or when needed
        CheckDistanceToPlayer();
    }


    /// <summary>
    // Method to check if the enemy is close enough to the player.
    /// </summary>
    /// <returns></returns>
    void CheckDistanceToPlayer()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < detectionRange)
        {
            // Enemy is close enough to the player, trigger the event
            OnEnemyCloseToPlayer?.Invoke();
        }
    }
}
