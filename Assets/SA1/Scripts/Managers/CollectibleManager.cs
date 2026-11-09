using UnityEngine;
using TMPro;

public class CollectibleManager : MonoBehaviour
{
    public static CollectibleManager Instance;

    [Header("Settings")]
    public int startingCollectibles = 6;

    [Header("UI")]
    public TMP_Text collectibleText;

    [Header("Win Screen")]
    public GameObject winScreen;

    private int remainingCollectibles;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        remainingCollectibles = startingCollectibles;

        if (winScreen != null)
        {
            winScreen.SetActive(false);
        }

        UpdateUI();
    }

    public void CollectItem()
    {
        remainingCollectibles--;

        if (remainingCollectibles < 0)
        {
            remainingCollectibles = 0;
        }

        UpdateUI();

        Debug.Log("Collectible Collected. Remaining: " + remainingCollectibles);

        if (remainingCollectibles == 0)
        {
            WinGame();
        }
    }

    private void UpdateUI()
    {
        if (collectibleText != null)
        {
            collectibleText.text = "Fuel Remaining: " + remainingCollectibles;
        }
    }

    private void WinGame()
    {
        Debug.Log("YOU WIN!");

        if (winScreen != null)
        {
            winScreen.SetActive(true);
        }

        Time.timeScale = 0f;
    }

    public int GetRemainingCollectibles()
    {
        return remainingCollectibles;
    }
}