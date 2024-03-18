using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class Telekinesis : MonoBehaviour
{
    public Transform playerCamera; // Reference to the player's camera
    public Transform playerLookAt;
    public float pickupDistance = 10f; // Maximum distance to pick up the object
    public KeyCode pickupKey = KeyCode.E; // Key to pick up the object
    private GameObject objectToPickup; // Reference to the object to pick up
    private bool isLookingAtObject = false; // Flag to track if the player is looking at a pickable object

    void Update()
    {
        // Check if the player is looking at an object to pick up
        RaycastHit hit;
        Vector3 direction = playerCamera.forward * 10f; // Calculate direction from player camera
        if (Physics.Raycast(playerLookAt.position, direction, out hit, pickupDistance))
        {
            Debug.Log("Hit object: " + hit.collider.gameObject.name);
            Debug.Log("Hit distance: " + hit.distance);

            // Check if the object to pick up matches the specific prefab and is within pickup angle
            if (hit.collider.CompareTag("pickup"))
            {
                // Store the object to pick up
                objectToPickup = hit.collider.gameObject;
                isLookingAtObject = true;
            }
            else
                isLookingAtObject = false;
        }
        else
            isLookingAtObject = false;

        // Check if the player presses the pickup key while looking at an object
        if (isLookingAtObject == true)
        {
            // Pick up the object
            Pickup();
        }
    }

    public void Pickup()
    {
        if (objectToPickup != null)
        {
            Debug.Log("Looking at pickup object");
            //Destroy(objectToPickup);
        }
        else
        {
            Debug.LogWarning("Attempted to pick up a null object.");
        }
    }

    void OnDrawGizmos()
    {
        // Draws a 15 unit long red line in front of the object
        Gizmos.color = Color.red;
        Vector3 direction = playerCamera.forward * 10f; // Calculate direction from player camera
        Gizmos.DrawRay(playerLookAt.position, direction);
    }
}