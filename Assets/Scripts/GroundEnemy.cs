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
    private int currentWaypointIndex;
    public int health;

    private GroundEnemyFOV fov;

    // Start is called before the first frame update
    void Start()
    {
        fov = GetComponent<GroundEnemyFOV>();

        navMeshAgent.SetDestination(waypoints[0].position);
        navMeshAgent.stoppingDistance = 1f;

        health = 100;

        animator = GetComponent<Animator>();
        animator.SetBool("isWalking", true);
    }

    // Update is called once per frame
    void Update()
    {

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
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("You were caught!");
        }
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