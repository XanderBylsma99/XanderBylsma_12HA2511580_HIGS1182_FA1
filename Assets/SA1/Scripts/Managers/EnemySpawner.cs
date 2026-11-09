using System.Collections;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject asteroidPrefab;
    public GameObject normalEnemyPrefab;
    public GameObject bossEnemyPrefab;
    public GameObject collectiblePrefab;

    [Header("Spawn Points")]
    public Transform[] asteroidSpawnPoints;
    public Transform[] enemySpawnPoints;
    public Transform[] bossSpawnPoints;
    public Transform[] collectibleSpawnPoints;

    [Header("UI")]
    public TMP_Text waveCountText;
    public TMP_Text nextWaveTimerText;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip waveSpawnSound;

    private int wavesRemaining = 3;

    private void Start()
    {
        UpdateWaveUI();
        StartCoroutine(StartWaves());
    }

    IEnumerator StartWaves()
    {
        // WAVE 1
        SpawnWave(20, 5, 0, 1);
        PlayWaveSound();

        wavesRemaining--;
        UpdateWaveUI();

        Debug.Log("Wave 1 Spawned");

        yield return StartCoroutine(UpdateTimer(90f));

        // WAVE 2
        SpawnWave(20, 10, 1, 2);
        PlayWaveSound();

        wavesRemaining--;
        UpdateWaveUI();

        Debug.Log("Wave 2 Spawned");

        yield return StartCoroutine(UpdateTimer(45f));

        // WAVE 3
        SpawnWave(20, 15, 3, 3);
        PlayWaveSound();

        wavesRemaining--;
        UpdateWaveUI();

        nextWaveTimerText.text = "Final Wave Active";

        Debug.Log("Wave 3 Spawned");
    }

    IEnumerator UpdateTimer(float duration)
    {
        float timer = duration;

        while (timer > 0)
        {
            nextWaveTimerText.text =
                "" + Mathf.CeilToInt(timer) + "s";

            timer -= Time.deltaTime;

            yield return null;
        }

        nextWaveTimerText.text = "";
    }

    void PlayWaveSound()
    {
        if (audioSource != null && waveSpawnSound != null)
        {
            audioSource.PlayOneShot(waveSpawnSound);
        }
    }

    void UpdateWaveUI()
    {
        if (waveCountText != null)
        {
            waveCountText.text = "" + wavesRemaining;
        }
    }

    void SpawnWave(
        int asteroidCount,
        int enemyCount,
        int bossCount,
        int collectibleCount)
    {
        SpawnObjects(
            asteroidPrefab,
            asteroidSpawnPoints,
            asteroidCount);

        SpawnObjects(
            normalEnemyPrefab,
            enemySpawnPoints,
            enemyCount);

        SpawnObjects(
            bossEnemyPrefab,
            bossSpawnPoints,
            bossCount);

        SpawnObjects(
            collectiblePrefab,
            collectibleSpawnPoints,
            collectibleCount);

        if (EnemyManager.Instance != null)
        {
            EnemyManager.Instance.AddAsteroids(asteroidCount);
            EnemyManager.Instance.AddEnemies(enemyCount);
            EnemyManager.Instance.AddBosses(bossCount);
        }
    }

    void SpawnObjects(
        GameObject prefab,
        Transform[] spawnPoints,
        int amount)
    {
        if (prefab == null || spawnPoints.Length == 0)
        {
            Debug.LogWarning("Prefab or Spawn Points missing!");
            return;
        }

        for (int i = 0; i < amount; i++)
        {
            Transform spawnPoint =
                spawnPoints[Random.Range(0, spawnPoints.Length)];

            Instantiate(
                prefab,
                spawnPoint.position,
                spawnPoint.rotation);
        }
    }
}