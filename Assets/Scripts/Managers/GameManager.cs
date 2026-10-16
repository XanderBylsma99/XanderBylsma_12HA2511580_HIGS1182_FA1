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
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI waveText;
    public GameObject gameOverPanel;
    public GameObject winPanel;

    [Header("Game Settings")]
    public int totalCollectibles;

    private int score;

    private float difficultyTimer;
    private int currentWave = 1;
   
    private bool gameEnded = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else                       //this ensures there is only one gameManager
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Time.timeScale = 1;

        score = 0;

       

        gameOverPanel.SetActive(false);
        winPanel.SetActive(false);

    }

    private void Update()
    {
        UpdateDifficulty();
        
        
    }

    public void UpdateScore()
    {
        score++;

        UpdateScoreUI();

        if(score >= totalCollectibles)
        {
            WinGame();
        }
    }

    void UpdateScoreUI()
    {
        scoreText.text = "" + score;
    }

    void UpdateDifficulty()
    {
        difficultyTimer += Time.deltaTime;

        if(difficultyTimer >= 30f)
        {
            difficultyTimer = 0f;

            currentWave++;

            waveText.text = "" + currentWave;
            Debug.Log("Difficulty Increased");

        }
    }

public void GameOver()
{
    if (gameEnded)
        return;
    gameEnded = true;
    gameOverPanel.SetActive(true);   //if gameover requirments are met call gameover panel and display you loose
        Debug.Log("Game Over?");
        Time.timeScale = 0;

       
    }
   public void WinGame()
    {
        //if (gameEnded)
        //    return;
        //gameEnded = true;
       
        winPanel.SetActive(true);//if requirments are met player win game
        Debug.Log("Player Won!!");
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        Time.timeScale = 1; //Get active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenuSC"); //thgis takes you back to the menu
    }
}
