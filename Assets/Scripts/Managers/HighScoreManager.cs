using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighScoreManager : MonoBehaviour
{
    [Header("Current Score Source")]
    public EnemyManager enemyManager;

    [Header("High Score UI")]
    
    public TMP_Text highScoreTMPText;

    private int highScore;

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateUI();
    }

    private void Update()
    {
        if (enemyManager == null)
            return;

        if (enemyManager.score > highScore)
        {
            highScore = enemyManager.score;

            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();

            UpdateUI();
        }
    }

    private void UpdateUI()
    {

        if (highScoreTMPText != null)
            highScoreTMPText.text = "High Score: " + highScore;
    }
}