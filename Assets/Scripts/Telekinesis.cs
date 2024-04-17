using UnityEngine;
using System.Collections;

public class Telekinesis : MonoBehaviour
{
    PlayerControls controls;

    private int liftWeight;
    public bool form;
    public Transform playerCamera; // Reference to the player's camera
    public Transform playerLookAt;
    public Transform shootPoint;
    public GameObject laser;
    public GameObject hitBox;
    Animator animator;
    public AudioSource shootingAudioSource;

    private float pickupDistance = 8f; // Maximum distance to pick up the object
    private GameObject objectToPickup; // Reference to the object to pick up
    private GameObject objectCarried;
    private Vector3 initialObjectPosition; // Initial position of the object when picked up
    private RaycastHit hit;
    private float knockbackForce = 0f;

    public bool leverFlipped = false;

    void Awake()
    {
       
        liftWeight = 1;
        controls = new PlayerControls();
        controls.Player.Interact.performed += ctx => OnInteract();
        controls.Player.Launch.performed += ctx => LaunchObject();
        controls.Player.Shoot.performed += ctx => Shoot();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        form = gameObject.GetComponent<Player>().form;
        if (form)
            liftWeight = 2;
        else if (!form)
            liftWeight = 1;

        // Check if the player is looking at an object to pick up
        Vector3 direction = playerCamera.forward * pickupDistance; // Calculate direction from player camera
        if (Physics.Raycast(playerLookAt.position, direction, out hit, pickupDistance))
        {
            if (hit.collider.CompareTag("pickup") && hit.rigidbody.mass <= liftWeight || hit.collider.CompareTag("lever")) //checks if player is looking at pickup object & is in correct form or if looking at a lever
            {
                objectToPickup = hit.collider.gameObject;
            }
        }
        else
        {
            objectToPickup = null;
        }
    }

    void LateUpdate()
    {
        if (objectCarried != null)
        {
            float distance = Vector3.Distance(playerLookAt.position, objectCarried.transform.position);
            Vector3 newPosition = playerLookAt.position + playerCamera.forward * pickupDistance;
            objectCarried.transform.position = newPosition;
        }
    }

    public void OnInteract()
    {
        if (objectToPickup != null)
        {
            Pickup();
        }
    }

    public void Pickup()
    {
        if(objectToPickup.CompareTag("lever"))
        {
            leverFlipped = true;
            return;
        }
        
        else if (objectToPickup != null && objectCarried == null)
        {
            objectCarried = objectToPickup;
            initialObjectPosition = objectCarried.transform.position;
        }
    }

    public void LaunchObject()
    {
        if (objectCarried != null)
        {
            objectCarried = null;
        }
    }

    public void Shoot()
    {
        Vector3 shootDirection = playerCamera.forward; // Calculate direction from player camera
        form = gameObject.GetComponent<Player>().form;

        if(!form)
        {
            GameObject laserInst = Instantiate(laser, new Vector3(shootPoint.position.x, shootPoint.position.y, shootPoint.position.z), Quaternion.LookRotation(shootDirection));
            laserInst.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, 1100f));

            animator.SetBool("isShooting", true);

            if (shootingAudioSource != null && shootingAudioSource.clip != null)
            {
                shootingAudioSource.Play();
            }
            StartCoroutine(StopShootingAfterDelay());
        }

        else if(form)
        {
            GameObject hitBoxInst = Instantiate(hitBox, new Vector3(shootPoint.position.x, shootPoint.position.y, shootPoint.position.z), Quaternion.LookRotation(shootDirection));

            Collider[] hitColliders = Physics.OverlapBox(hitBoxInst.transform.position, hitBoxInst.transform.localScale / 2);

            foreach(Collider hitCollider in hitColliders)
            {
                // Check if the collider belongs to ground enemy
                if(hitCollider.CompareTag("groundEnemy"))
                {
                    // Apply knockback force away from player
                    Rigidbody enemyRigidbody = hitCollider.GetComponent<Rigidbody>();
                    if(enemyRigidbody != null)
                    {
                        knockbackForce = 20000f; 
                        enemyRigidbody.AddForce(shootDirection * knockbackForce);
                        StartCoroutine(RemoveKnockback(enemyRigidbody));
                    }
                }
            }
        }
    }

    private IEnumerator StopShootingAfterDelay()
    {
        yield return new WaitForSeconds(1f); 
        animator.SetBool("isShooting", false);
    }

    private IEnumerator RemoveKnockback(Rigidbody enemyRigidbody)
    {
        yield return new WaitForSeconds(.18f);
        if(enemyRigidbody != null)
            enemyRigidbody.velocity = Vector3.zero;
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 direction = playerCamera.forward * pickupDistance; // Calculate direction from player camera
        Gizmos.DrawRay(playerLookAt.position, direction);
    }

    void OnEnable()
    {
        controls.Player.Enable();
    }

    void OnDisable()
    {
        controls.Player.Disable();
    }
}