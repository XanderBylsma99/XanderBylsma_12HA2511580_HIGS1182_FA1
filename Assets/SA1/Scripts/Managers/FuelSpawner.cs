using UnityEngine;

public class FuelSpawner : MonoBehaviour
{
    public GameObject collectiblePrefab;
    public float collectibleCount = 4;
    public Transform[] spawnPoint;

    void Start()
    {
        SpawnFuel();
    }

    void SpawnFuel()
    {
        for (int i = 0; i < collectibleCount; i++)
        {
            int index = Random.Range(minInclusive: 0, spawnPoint.Length);
            Instantiate(collectiblePrefab, spawnPoint[index].position, spawnPoint[index].rotation); //Spawns fuel
            Debug.Log("Fuel Spawned");
        }
    }
}
