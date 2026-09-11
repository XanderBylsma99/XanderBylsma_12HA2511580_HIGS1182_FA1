using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroid_bigPrefab;
    public GameObject asteroid_meduimPrefab;
    public float asteroid_bigCount = 5;
    public float asteroid_meduimCount = 5;
    public Transform[] spawnPoint;
    public float spawnTime = 1f;
    private float time;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnAsteroids();
    }

    void SpawnAsteroids()
    {
        for (int i = 0; i < asteroid_bigCount; i++)
        {
            int index = Random.Range(minInclusive: 0, spawnPoint.Length);
            Instantiate(asteroid_bigPrefab, spawnPoint[index].position, spawnPoint[index].rotation);
            Debug.Log("Big Asteroids Spawned");
        }


        for (int i = 0; i < asteroid_meduimCount; i++)
        {
            int index = Random.Range(minInclusive: 0, spawnPoint.Length);
            Instantiate(asteroid_meduimPrefab, spawnPoint[index].position, spawnPoint[index].rotation);
            Debug.Log("Meduim Asteroids Spawned");
        }
    }
}
