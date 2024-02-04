using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClone : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyPrefab;  //hold the different enemy prefabs that can be cloned.

    private readonly List<GameObject> clonedEnemies = new();// List to keep track of the cloned enemies during runtime.

    [Tooltip("Random cloning position relative to this gameobject position")]
    [SerializeField] private int numberOfEnemies = 8;
    [SerializeField] private float minX = -2.5f;
    [SerializeField] private float maxX = 2.5f;
    [SerializeField] private float minZ = 32f;
    [SerializeField] private float maxZ = 37f;

    void Start()
    {
        // Start spawning enemies after a delay
        InvokeRepeating(nameof(SpawnEnemies), 2f, 2f);
    }


    /// <summary>
    /// Spawns a specified number of enemies at random positions within the defined range.
    /// </summary>
    /// <returns></returns>
    void SpawnEnemies()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            float randomX = Random.Range(minX, maxX);
            float randomZ = Random.Range(minZ, maxZ);

            Vector3 spawnPosition = new(randomX, -1, randomZ);
            GameObject enemyClone = Instantiate(enemyPrefab[0], spawnPosition, Quaternion.Euler(0, 180f, 0));
            enemyClone.GetComponent<SphereCollider>().isTrigger = false;

            clonedEnemies.Add(enemyClone);
        }
        StartCoroutine(DeactivateEnemyColliders());

    }


    /// <summary>
    /// Deactivates the colliders of cloned enemies after a short delay to prevent collisions during spawning.
    /// </summary>
    /// <returns></returns>
    private IEnumerator DeactivateEnemyColliders()
    {
        yield return new WaitForSeconds(0.2f);
        foreach (GameObject enemy in clonedEnemies)
        {
            enemy.GetComponent<SphereCollider>().isTrigger = true;
        }
        clonedEnemies.Clear();
    }
}
