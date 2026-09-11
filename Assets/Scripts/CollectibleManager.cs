using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
public class CollectibleManager : MonoBehaviour
{
    public GameObject collectiblePrefab;
    public int collectibleCount = 1;
    public Transform[] spawnPoint; 
    public float spawnTime = 1f;
    private float time;


    private void Start()
    {
        time = Time.deltaTime;
        if (time >= spawnTime)
        {
            time = 0f;
            SpawnCollectibles();
        }
    }
  
    // Spawns all fuel collectibles.//
    private void SpawnCollectibles()
    {
        
        {
            int index = Random.Range(minInclusive:0, spawnPoint.Length);
            Instantiate(collectiblePrefab, spawnPoint[index].position, spawnPoint[index].rotation);
            Debug.Log("Feul Spawned");
        }

        

    }
}