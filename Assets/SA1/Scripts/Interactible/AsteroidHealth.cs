using UnityEngine;

public class AsteroidHealth : MonoBehaviour
{
    public int health = 1;

    public void Damage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(this.gameObject);
            Debug.Log("Asteroid Destroyed");
        }
    }

    private void Die()
    {
        if (EnemyManager.Instance != null)
        {
            EnemyManager.Instance.AsteroidDestroyed();
        }

        Destroy(gameObject);
    }
}