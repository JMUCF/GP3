using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class GroundEnemy : MonoBehaviour
{
    public Transform target;
    public int speed = 115;
    public Animator animator;
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;
    public GameObject hitBox;
    private float knockbackForce = 0f;
    private int currentWaypointIndex;
    public int health;
    private GroundEnemyFOV fov;
    private HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        fov = GetComponent<GroundEnemyFOV>();

        navMeshAgent.SetDestination(waypoints[0].position);
        navMeshAgent.stoppingDistance = 1f;

        health = 100;

        animator = GetComponent<Animator>();
        animator.SetBool("isWalking", true);
        animator.SetBool("isAttacking", false);
    }

    // Update is called once per frame
    void Update()
    {
         if (!animator.GetBool("isAttacking")) // Check if not attacking
        {   
            animator.SetBool("isWalking", true); // Set isWalking to true only if not attacking
        }
        else
        {
            animator.SetBool("isWalking", false); // Set isWalking to false if attacking
        }

        if (fov.visibleTarget.Count > 0)
            navMeshAgent.SetDestination(target.transform.position);

        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            navMeshAgent.SetDestination(waypoints[currentWaypointIndex].position);
        }

        
        
        if (health <= 0)
        {
            Destroy(gameObject);
        }

        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            healthBar = collision.gameObject.GetComponent<HealthBar>();
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            
            if(enemyRigidbody != null)
            {
                healthBar.TakeDamage(10);
                knockbackForce = 3000f;
                enemyRigidbody.AddForce(transform.up * (knockbackForce/2));
                enemyRigidbody.AddForce(transform.forward * knockbackForce);
                StartCoroutine(RemoveKnockback(enemyRigidbody));
                animator.SetBool("isAttacking", true);
                animator.SetBool("isWalking", false);
            }
            Debug.Log("boss has collided");
        }
    }

    private IEnumerator RemoveKnockback(Rigidbody enemyRigidbody)
    {
        yield return new WaitForSeconds(.18f);
        if(enemyRigidbody != null)
            enemyRigidbody.velocity = Vector3.zero;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "hitbox")
        {
            health -= 25;
            Destroy(other.gameObject);
        }
    }
}