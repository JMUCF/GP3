using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject laser;

    public float viewRadius;
    [Range(0,360)]
    public float viewAngle;
    public bool isPaused = false;
    public LayerMask targetMask;
    public LayerMask obstacleMask;
    public List<Transform> visibleTarget = new List<Transform>();
    public AudioSource shootingAudioSource;

    void Start()
    {
        StartCoroutine(FindTarget(.1f));
    }

    IEnumerator FindTarget(float delay)
    {
        while(true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTarget();
        }
    }

    void FindVisibleTarget()
    {
        visibleTarget.Clear();
        Collider[] targetInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);
        for(int i = 0; i < targetInViewRadius.Length; i++)
        {
            Transform target = targetInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if(Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
            {
                float dstToTarget = Vector3.Distance(transform.position, target.position);
                if(!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))
                {
                    visibleTarget.Add(target);
                    Quaternion lookRotation = Quaternion.LookRotation(dirToTarget);
                    lookRotation *= Quaternion.Euler(0, 180f, 0);
                    transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 100f);
                    Shoot();
                }
            }
        }
    }

    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
            angleInDegrees += transform.eulerAngles.y;
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }

    public void Shoot()
    {
        Vector3 shootDirection = -transform.forward; // Calculate direction from player camera

        GameObject laserInst = Instantiate(laser, new Vector3 (transform.position.x, transform.position.y, transform.position.z + -1f), Quaternion.LookRotation(shootDirection));
        laserInst.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, 1100f));

        if (shootingAudioSource != null && shootingAudioSource.clip != null)
        {
            shootingAudioSource.Play();
        }
    }
}
