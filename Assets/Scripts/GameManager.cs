using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
public class GameManager : MonoBehaviour
{
    // Singleton reference 
    public static GameManager Instance;


    [Header("UI")]

    public TextMeshProUGUI scoreText;
    public GameObject gameOverPanel;
    public GameObject winPanel;

    [Header("Game Settings")]
    public int totalCollectibles = 1;

    private int currentScore = 0;

    private bool gameEnded = false;

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

    void Start()
    {
        Time.timeScale = 1;


        gameOverPanel.SetActive(false);
        winPanel.SetActive(false);
    }


public void GameOver()
{
    if (gameEnded)
        return;
    gameEnded = true;
    gameOverPanel.SetActive(true);
        Debug.Log("Game Over?");
        Time.timeScale = 0;
}
   public void WinGame()
    {
        if (gameEnded)
            return;
        gameEnded = true;
        winPanel.SetActive(true);
        Debug.Log("Player Won!!");
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenuSC");
    }
}
