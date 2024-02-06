using System.Collections;
using UnityEngine;

public class EnemyColliderAttackHandler : MonoBehaviour
{
    [SerializeField] private GameObject enemyObject;
    [SerializeField] private Transform player;
    [SerializeField] private Animator animator;

    [SerializeField] private RoadMove roadRef;
    private float roadSpeed;

    [SerializeField] private float decreaseRate = 2.0f; // Adjust this value to control how fast the speed decreases

    private EnemyMovements movements;

    private bool isPlayerDetected = false;
    private bool isEnemyMoving = true;

    private void Start()
    {
        movements = enemyObject.GetComponent<EnemyMovements>();
        animator = enemyObject.GetComponent<Animator>();
        roadSpeed = roadRef.RoadSpeed;
    }


    /// <summary>
    /// Handles collisions with the player and rotates the enemy to face the player.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Get the direction to the player
            Vector3 directionToPlayer = other.transform.position - enemyObject.transform.position;

            // Ignore the vertical (y) component to make the enemy face the player horizontally
            directionToPlayer.y = 0;

            // Rotate the enemy to face the player
            enemyObject.transform.rotation = Quaternion.LookRotation(directionToPlayer);

            isPlayerDetected = true;

            animator.SetTrigger("Attack");
        }
    }


    /// <summary>
    /// Rotate the enemy to face the Player.
    /// </summary>
    public void FaceTarget()
    {
        // Calculate the direction to the target
        Vector3 direction = (player.position - enemyObject.transform.position).normalized;

        // Calculate the rotation needed to face the target and ignore rotation in y-axis
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

        // Smoothly rotate the enemy towards the target
        enemyObject.transform.rotation = Quaternion.Slerp(enemyObject.transform.rotation, lookRotation, Time.deltaTime * 5f);


        if (isEnemyMoving)
        {
            StartCoroutine(SlowDownOverTime());
            isEnemyMoving = false;
        }
    }


    /// <summary>
    /// Coroutine to gradually slow down the enemy's speed over time until it matches the road speed.
    /// </summary>
    /// <returns></returns>
    IEnumerator SlowDownOverTime()
    {
        // Make the enemy the same speed as the road
        while (movements.ObjectSpeed > roadSpeed)
        {
            // Gradually decrease the speed over time
            movements.ObjectSpeed -= decreaseRate * Time.deltaTime;

            // Move the enemy using the updated speed
            enemyObject.transform.Translate(movements.ObjectSpeed * Time.deltaTime * Vector3.forward);

            // Move the enemy towards the player
            enemyObject.transform.Translate(2.5f * Time.deltaTime * Vector3.forward);

            yield return null;
        }
    }


    private void Update()
    {
        if (isPlayerDetected)
        {
            FaceTarget();
        }
    }
}
