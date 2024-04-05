using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float detectionRange = 10f; // Range within which the enemy detects the player

    private Transform playerTransform; // Reference to the player's transform
    private bool isPlayerInRange = false; // Flag to track if the player is in range

    void Start()
    {
        // Find the player's GameObject and get its transform
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Check if the player is in range
        if (playerTransform != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
            if (distanceToPlayer <= detectionRange)
            {
                isPlayerInRange = true;
                // Rotate the enemy to look towards the player's position
                Vector3 direction = playerTransform.position - transform.position;
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

                // Do something else if the player is in range, such as attacking or chasing
                // For example:
                // AttackPlayer();
            }
            else
            {
                isPlayerInRange = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }
}
