using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovingPlatform : MonoBehaviour
{
    public Transform player;
    public int speed;
    public Transform[] waypoints;
    private int currentWaypointIndex;
    private bool check;

    // Start is called before the first frame update
    void Start()
    {
        speed = 4;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position == waypoints[0].transform.position)
        {
            check = false;
        }
        else if (transform.position == waypoints[1].transform.position)
        {
            check = true;
        }

        transform.position = Vector3.MoveTowards(transform.position, check ? waypoints[0].transform.position : waypoints[1].transform.position, Time.deltaTime * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}