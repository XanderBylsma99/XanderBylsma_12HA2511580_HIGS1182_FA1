using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    [Header("References")]
    public NavMeshAgent agent;
    public Transform player;

    [Header("Patrol")]
    public Transform[] patrolPoints;
    private int currentPatrolPoint = 0;

    [Header("Movement")]
    public float patrolSpeed = 3.5f;
    public float chaseSpeed = 6f;

    [Header("Detection")]
    public float detectionRange = 30f;
    public float attackRange = 2.5f;
    public LayerMask obstacleMask;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip alertSound;

    private bool isChasing = false;
    private bool soundPlayed = false;

    private void Start()
    {
        if (agent == null)
            agent = GetComponent<NavMeshAgent>();

        agent.speed = patrolSpeed;

        if (patrolPoints.Length > 0)
        {
            agent.SetDestination(patrolPoints[0].position);
        }
    }

    private void Update()
    {
        if (player == null)
            return;

        float distanceToPlayer =
            Vector3.Distance(transform.position, player.position);

        if (CanSeePlayer() && distanceToPlayer <= detectionRange)
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
        }
    }

    bool CanSeePlayer()
    {
        Vector3 direction =
            (player.position - transform.position).normalized;

        float distance =
            Vector3.Distance(transform.position, player.position);

        if (!Physics.Raycast(
            transform.position + Vector3.up,
            direction,
            distance,
            obstacleMask))
        {
            return true;
        }

        return false;
    }

    void Patrol()
    {
        if (isChasing)
        {
            isChasing = false;
            soundPlayed = false;
            agent.speed = patrolSpeed;

            agent.SetDestination(
                patrolPoints[currentPatrolPoint].position);
        }

        if (patrolPoints.Length == 0)
            return;

        if (!agent.pathPending &&
            agent.remainingDistance <= agent.stoppingDistance)
        {
            currentPatrolPoint++;

            if (currentPatrolPoint >= patrolPoints.Length)
                currentPatrolPoint = 0;

            agent.SetDestination(
                patrolPoints[currentPatrolPoint].position);
        }
    }

    void ChasePlayer()
    {
        isChasing = true;

        agent.speed = chaseSpeed;
        agent.SetDestination(player.position);

        if (!soundPlayed &&
            audioSource != null &&
            alertSound != null)
        {
            audioSource.PlayOneShot(alertSound);
            soundPlayed = true;
        }

        float distance =
            Vector3.Distance(transform.position, player.position);

        if (distance <= attackRange)
        {
            Debug.Log("Enemy Attacking Player");
            // Add your attack code here
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(
            transform.position,
            detectionRange);
    }
}