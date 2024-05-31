using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // List to hold the spawn points
    public List<GameObject> spawnPoints;

    // Enemy prefab to spawn
    public GameObject enemyPrefab;

    // Time between spawns
    public float spawnInterval = 2f;
    private float timer;

    void Start()
    {
        // Initialize the timer
        timer = spawnInterval;
    }

    void Update()
    {
        // Countdown timer
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            // Reset the timer
            timer = spawnInterval;
            // Spawn an enemy at a random spawn point
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        if (spawnPoints.Count > 0)
        {
            // Select a random spawn point
            int spawnIndex = Random.Range(0, spawnPoints.Count);
            GameObject spawnPoint = spawnPoints[spawnIndex];

            // Instantiate the enemy at the spawn point
            Instantiate(enemyPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
        }
    }
}
