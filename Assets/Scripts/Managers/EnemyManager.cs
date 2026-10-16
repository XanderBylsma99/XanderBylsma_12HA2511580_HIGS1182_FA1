using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;

    [Header("Score")]
    public int score = 0;

    [Header("UI")]
    
    public TMP_Text scoreTMPText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateScore();
    }

    public void AddPoints(int points)
    {
        score += points;
        UpdateScore();
    }

    void UpdateScore()
    {
      

        if (scoreTMPText != null)
            scoreTMPText.text = "Score: " + score;
    }
}