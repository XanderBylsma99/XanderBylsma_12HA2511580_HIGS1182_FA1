using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour
{
    [Header("References")]
    public Transform player;

    [Header("Distances")]
    public float detectionRange = 50f;
    public float attackRange = 5f;

    [Header("Movement")]
    public float patrolSpeed = 5f;
    public float chaseSpeed = 10f;
    public float rotationSpeed = 5f;

    [Header("Patrol")]
    public float patrolRadius = 25f;
    public float waypointReachedDistance = 2f;

    private Vector3 patrolPoint;

    private enum EnemyState
    {
        Patrol,
        Chase,
        Attack
    }

    private EnemyState currentState;

    private void Start()
    {
        if (player == null)
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            Debug.Log("Player Found: " + player);
            if (playerObject != null)
            {
                player = playerObject.transform;
            }
        }

        GeneratePatrolPoint();
    }

    private void Update()
    {
        if (player == null)
            return;

        float distanceToPlayer =
            Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackRange)
        {
            currentState = EnemyState.Attack;
        }
        else if (distanceToPlayer <= detectionRange)
        {
            currentState = EnemyState.Chase;
        }
        else
        {
            currentState = EnemyState.Patrol;
        }

        switch (currentState)
        {
            case EnemyState.Patrol:
                Patrol();
                break;

            case EnemyState.Chase:
                ChasePlayer();
                break;

            case EnemyState.Attack:
                AttackPlayer();
                break;
        }
    }

    void Patrol()
    {
        MoveTowards(patrolPoint, patrolSpeed);

        float distance =
            Vector3.Distance(transform.position, patrolPoint);

        if (distance <= waypointReachedDistance)
        {
            GeneratePatrolPoint();
        }
    }

    void ChasePlayer()
    {
        MoveTowards(player.position, chaseSpeed);
    }

    void AttackPlayer()
    {
        FaceTarget(player.position);

        Debug.Log("Enemy Attacking!");
    }

    void MoveTowards(Vector3 targetPos, float speed)
    {
        Vector3 direction =
            (targetPos - transform.position).normalized;

        direction.y = 0;

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation =
                Quaternion.LookRotation(direction);

            transform.rotation =
                Quaternion.Slerp(
                    transform.rotation,
                    targetRotation,
                    rotationSpeed * Time.deltaTime);
        }

        transform.position +=
            transform.forward *
            speed *
            Time.deltaTime;
    }

    void FaceTarget(Vector3 targetPos)
    {
        Vector3 direction =
            (targetPos - transform.position).normalized;

        direction.y = 0;

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation =
                Quaternion.LookRotation(direction);

            transform.rotation =
                Quaternion.Slerp(
                    transform.rotation,
                    targetRotation,
                    rotationSpeed * Time.deltaTime);
        }
    }

    void GeneratePatrolPoint()
    {
        Vector2 randomCircle =
            Random.insideUnitCircle * patrolRadius;

        patrolPoint = new Vector3(
            transform.position.x + randomCircle.x,
            transform.position.y,
            transform.position.z + randomCircle.y
        );
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enemy Hit Player");

            GameManager.Instance.GameOver();
        }
    }
}

//Just a quick note i really hope this is the correct way for EnemyAi i tried navmesh but for some unexplained reason
//everytime i clicked on add Nav Mesh Agent my Unity project kept crashing and when i reopen the project it kept saying enter safemode
//i really do not know if i am allowed to ask this in this way on my project script but is this a common error or did i do something wrong
//from my side i tried to follow the prescribed videos in unit 6 exactly but as soon as i go to add component inside the inspector my computer freezes
//until the batery dies but when i stoped trying to add manual spawn points and Nav Mesh Agent i only had one crash after that//
