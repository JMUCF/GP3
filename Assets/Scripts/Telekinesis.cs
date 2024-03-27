using UnityEngine;

public class Telekinesis : MonoBehaviour
{
    PlayerControls controls;

    public Transform playerCamera; // Reference to the player's camera
    public Transform playerLookAt;
    public GameObject laser;

    private float pickupDistance = 4f; // Maximum distance to pick up the object
    private GameObject objectToPickup; // Reference to the object to pick up
    private GameObject objectCarried;
    private Vector3 initialObjectPosition; // Initial position of the object when picked up
    private RaycastHit hit;

    void Awake()
    {
        controls = new PlayerControls();
        controls.Player.Interact.performed += ctx => OnInteract();
        controls.Player.Launch.performed += ctx => LaunchObject();
        controls.Player.Shoot.performed += ctx => Shoot();
    }

    void Update()
    {
        // Check if the player is looking at an object to pick up
        Vector3 direction = playerCamera.forward * pickupDistance; // Calculate direction from player camera
        if (Physics.Raycast(playerLookAt.position, direction, out hit, pickupDistance))
        {
            if (hit.collider.CompareTag("pickup"))
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
        if (objectToPickup != null && objectCarried == null)
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

        GameObject laserInst = Instantiate(laser, new Vector3 (playerLookAt.position.x - .25f, playerLookAt.position.y - .25f, playerLookAt.position.z + .25f), Quaternion.LookRotation(shootDirection));
        laserInst.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, 1100f));
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
