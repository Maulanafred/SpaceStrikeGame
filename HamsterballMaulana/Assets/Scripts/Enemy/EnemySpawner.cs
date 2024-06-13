using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Enemy prefab for level 1
    public GameObject enemyLevel1Prefab;

    // List of spawn points
    public List<Transform> spawnPoints;

    // Time interval between spawns
    public float spawnInterval = 2.0f;

    // Bool to control spawning
    private bool spawn = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        // Iterate through the list of spawn points
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            if (!spawn)
                yield break;

            SpawnEnemy(spawnPoints[i]);

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnEnemy(Transform spawnPoint)
    {
        // Set enemy prefab for level 1
        GameObject enemyPrefab = enemyLevel1Prefab;

        // Instantiate the enemy at the spawn point
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
