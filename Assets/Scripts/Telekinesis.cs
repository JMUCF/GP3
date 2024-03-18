using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class Telekinesis : MonoBehaviour
{
    PlayerControls controls;

    public Transform playerCamera; // Reference to the player's camera
    public Transform playerLookAt;
    public float pickupDistance = 10f; // Maximum distance to pick up the object
    public KeyCode pickupKey = KeyCode.E; // Key to pick up the object
    private GameObject objectToPickup; // Reference to the object to pick up
    private GameObject objectCarried;
    private bool isLookingAtObject = false; // Flag to track if the player is looking at a pickable object
    private bool isCarryingObject = false; // Flag to track if the player is currently carrying an object
    private RaycastHit hit;

    void Awake()
    {
        controls = new PlayerControls();
        controls.Player.Interact.performed += ctx => OnInteract();
        controls.Player.Launch.performed += ctx => LaunchObject();
    }

    void Update()
    {
        // Check if the player is looking at an object to pick up
        Vector3 direction = playerCamera.forward * 10f; // Calculate direction from player camera
        if (Physics.Raycast(playerLookAt.position, direction, out hit, pickupDistance))
        {
            if (hit.collider.CompareTag("pickup"))
            {
                objectToPickup = hit.collider.gameObject;
                isLookingAtObject = true;
            }
            else
                isLookingAtObject = false;
        }
        else
            isLookingAtObject = false;

        /*if(isCarryingObject)
        {
            Debug.Log("We are carrying something");
            float distance = Vector3.Distance (playerLookAt.transform.position, objectCarried.transform.position);
            if(distance > 2)
                objectCarried.transform.position = hit.point;
        }*/

        if (isCarryingObject)
        {
            float distance = Vector3.Distance (playerLookAt.transform.position, objectCarried.transform.position);
            Debug.Log("Distance between player and object: " + distance);
            Vector3 newPosition = playerLookAt.position + playerLookAt.forward * distance;
            objectCarried.transform.position = newPosition;
        }
    }

    public void OnInteract()
    {
        if (isLookingAtObject && !isCarryingObject)
        {
            Pickup();
        }
    }

    public void Pickup()
    {
        if (objectToPickup != null)
        {
            objectCarried = objectToPickup;
            objectCarried.transform.position = hit.point;
            isCarryingObject = true;
        }
        else
        {
            Debug.LogWarning("Attempted to pick up a null object.");
        }
    }

    public void LaunchObject()
    {
        if (isCarryingObject)
        {
            // Reset the object's position and release it
            objectToPickup.transform.position = objectToPickup.GetComponent<Transform>().position;
            isCarryingObject = false;
            objectToPickup = null; // Clear the reference to the object
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 direction = playerCamera.forward * 10f; // Calculate direction from player camera
        Gizmos.DrawRay(playerLookAt.position, direction);
    }
}
