using UnityEngine;
using TMPro;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health")]
    public int maxLives = 3;

    [Header("UI")]
    public TMP_Text healthText;

    [Header("Game Over")]
    public GameObject loseScreen;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip deathSound;

    private int currentLives;
    private bool isDead = false;

    private void Start()
    {
        currentLives = maxLives;

        if (loseScreen != null)
        {
            loseScreen.SetActive(false);
        }

        UpdateHealthUI();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isDead)
            return;

        if (collision.gameObject.CompareTag("Asteroid"))
        {
            TakeDamage(1);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(1);
        }

        if (collision.gameObject.CompareTag("BossEnemy"))
        {
            Die();
        }
    }

    private void TakeDamage(int damage)
    {
        currentLives -= damage;

        if (currentLives < 0)
        {
            currentLives = 0;
        }

        UpdateHealthUI();

        if (currentLives <= 0)
        {
            Die();
        }
    }

    private void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "" + currentLives;
        }
    }

    private void Die()
    {
        if (isDead)
            return;

        isDead = true;

        Debug.Log("Player Died");

        StartCoroutine(DeathSequence());
    }

    private IEnumerator DeathSequence()
    {
        // Play death sound
        if (audioSource != null && deathSound != null)
        {
            audioSource.PlayOneShot(deathSound);
        }

        // Show lose screen
        if (loseScreen != null)
        {
            loseScreen.SetActive(true);
        }

        // Stop game
        Time.timeScale = 0f;

        // Wait for sound to finish in real time
        yield return new WaitForSecondsRealtime(2f);

        Destroy(gameObject);
    }
}