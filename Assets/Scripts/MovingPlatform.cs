using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovingPlatform : MonoBehaviour
{

    public Transform target;
    public int speed;
    public Transform[] waypoints;
    private int currentWaypointIndex;
    private bool check;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (target.transform.position == waypoints[0].transform.position)
        {
            check = false;
        }
        else if (target.transform.position == waypoints[1].transform.position)
        {
            check = true;
        }

        target.transform.position = Vector3.MoveTowards(target.transform.position, check ? waypoints[0].transform.position : waypoints[1].transform.position, Time.deltaTime * speed);
    }
}
