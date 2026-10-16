using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [Header("Asteroid Prefabs")]
    public GameObject asteroid1;
    public GameObject asteroid2;
    public GameObject asteroid3;
    public GameObject asteroid4;

    [Header("Enemy Prefabs")]
    public GameObject enemy1;
    public GameObject enemy2;

    [Header("Spawn Area")]
    public float spawnArea = 60f;

    [Header("Spawn Amounts")]
    public int asteroidsPerType = 15;
    public int enemiesPerType = 2;

    private void Start()
    {
        SpawnStartingObjects();

        StartCoroutine(EnemyWaveSpawner());
    }

    void SpawnStartingObjects()
    {
        // Spawn 15 of each asteroid
        SpawnMultiple(asteroid1, asteroidsPerType);
        SpawnMultiple(asteroid2, asteroidsPerType);
        SpawnMultiple(asteroid3, asteroidsPerType);
        SpawnMultiple(asteroid4, asteroidsPerType);

        // Spawn 2 of each enemy at game start
        SpawnMultiple(enemy1, enemiesPerType);
        SpawnMultiple(enemy2, enemiesPerType);
    }

    IEnumerator EnemyWaveSpawner()
    {
        while (true)
        {
            float waitTime = 15f;

            if (EnemyManager.Instance != null &&
                EnemyManager.Instance.score >= 100)
            {
                waitTime = 7f;
            }

            yield return new WaitForSeconds(waitTime);

            SpawnEnemyWave();
        }
    }

    void SpawnEnemyWave()
    {
        // Spawn 2 of each enemy every wave
        SpawnMultiple(enemy1, enemiesPerType);
        SpawnMultiple(enemy2, enemiesPerType);

        Debug.Log("Enemy Wave Spawned");
    }

    void SpawnMultiple(GameObject prefab, int amount)
    {
        if (prefab == null)
        {
            Debug.LogWarning("Missing Prefab!");
            return;
        }

        for (int i = 0; i < amount; i++)
        {
            Vector3 randomPosition = GetRandomPosition();

            Instantiate(
                prefab,
                randomPosition,
                Quaternion.identity
            );
        }
    }

    Vector3 GetRandomPosition()
    {
        float halfArea = spawnArea / 2f;

        return transform.position + new Vector3(
            Random.Range(-halfArea, halfArea),
            0f,
            Random.Range(-halfArea, halfArea)
        );
    }
}