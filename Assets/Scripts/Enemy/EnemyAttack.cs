using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [Header("Attack Settings")]
    public Transform player;
    public float attackRange = 5f;

    private bool playerInRange;
   

    void Update()
    {
        if (player == null) return;
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        playerInRange = distanceToPlayer <= attackRange;

        if (playerInRange)
        {
            Attack();
        }
    }

    void Attack()
    {
        Debug.Log("Enemy Attacking!");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            Debug.Log("GameOver Ship Collided with Pirate Ship");

            GameManager.Instance.GameOver();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
