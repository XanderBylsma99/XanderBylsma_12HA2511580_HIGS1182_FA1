using UnityEditor.Rendering;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject prefabBoss;
    public GameObject prefab;
    public Transform[] spawnPoint;
    public float spawnTime = 1f;
    public int enemyNum = 5;
    private float time;
    private int enemyCount = 0;

    private void Update()
    {
        if (enemyCount >= enemyNum) return;

            time += Time.deltaTime;
        if (time >= spawnTime)
        {
            time = 0f;
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        int index = Random.Range(minInclusive: 0, spawnPoint.Length);
        Instantiate(prefab, spawnPoint[index].position, spawnPoint[index].rotation);
        enemyCount++;
        Instantiate(prefabBoss, spawnPoint[index].position, spawnPoint[index].rotation);
        enemyCount++;
    }
}
