using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 3f;
    public float minSpawnRadius = 5f;
    public float maxSpawnRadius = 8f;
    public Transform playerTransform;

    float gameAreaMinX = -23;
    float gameAreaMaxX = 23;
    float gameAreaMinY = -17;
    float gameAreaMaxY = 17;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnInterval)
        {
            SpawnEnemy();
            timer = 0;
        }
    }

    void SpawnEnemy()
    {
        float randomAngle = Random.Range(0f, 360f);

        float angleInRadians = randomAngle * Mathf.Deg2Rad;

        // random spawn radius between min and max
        float randomSpawnRadius = Random.Range(minSpawnRadius, maxSpawnRadius);

        // Get the x and y components of the spawn position
        float xOffset = Mathf.Cos(angleInRadians) * randomSpawnRadius;
        float yOffset = Mathf.Sin(angleInRadians) * randomSpawnRadius;

        // Calculate the spawn position based on the player's position and the random spawn radius
        Vector3 spawnPosition = playerTransform.position + new Vector3(xOffset, yOffset, 0f);

        //can't spawn enemy outside of border
        spawnPosition.x = Mathf.Clamp(spawnPosition.x, gameAreaMinX, gameAreaMaxX);
        spawnPosition.y = Mathf.Clamp(spawnPosition.y, gameAreaMinY, gameAreaMaxY);

        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
