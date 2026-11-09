using UnityEngine;
using TMPro;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;

    [Header("Enemy Counts")]
    public int asteroidCount;
    public int enemyCount;
    public int bossCount;

    [Header("Score")]
    public int score;

    [Header("UI")]
    public TMP_Text asteroidText;
    public TMP_Text enemyText;
    public TMP_Text bossText;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateUI();
    }

    public void AddAsteroids(int amount)
    {
        asteroidCount += amount;
        UpdateUI();
    }

    public void AddEnemies(int amount)
    {
        enemyCount += amount;
        UpdateUI();
    }

    public void AddBosses(int amount)
    {
        bossCount += amount;
        UpdateUI();
    }

    public void AsteroidDestroyed()
    {
        asteroidCount--;

        if (asteroidCount < 0)
            asteroidCount = 0;

        score += 2;

        UpdateUI();
    }

    public void EnemyDestroyed()
    {
        enemyCount--;

        if (enemyCount < 0)
            enemyCount = 0;

        score += 5;

        UpdateUI();
    }

    public void BossDestroyed()
    {
        bossCount--;

        if (bossCount < 0)
            bossCount = 0;

        score += 10;

        UpdateUI();
    }

    private void UpdateUI()
    {
        if (asteroidText != null)
            asteroidText.text = "" + asteroidCount;

        if (enemyText != null)
            enemyText.text = "" + enemyCount;

        if (bossText != null)
            bossText.text = "" + bossCount;
    }
}