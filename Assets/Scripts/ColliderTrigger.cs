using UnityEngine;

public class ColliderTrigger : MonoBehaviour
{
    public GameObject colliderToActivate; // Reference to the collider GameObject to activate
    public string leverTag = "Lever"; // Tag of the lever to interact with
    public KeyCode interactKey = KeyCode.X; // Key to interact with the lever

    private bool colliderActivated = false; // Flag to track if the collider has been activated

    void Update()
    {
        // Check if the collider has not been activated and the player presses the interact key
        if (!colliderActivated && Input.GetKeyDown(interactKey))
        {
            // Check if there's a lever with the specified tag nearby
            Collider[] colliders = Physics.OverlapSphere(transform.position, 2f); // Check in a sphere around the script's position
            foreach (Collider collider in colliders)
            {
                if (collider.CompareTag(leverTag))
                {
                    // Activate the collider and set the flag
                    colliderToActivate.SetActive(true);
                    colliderActivated = true;
                    break; // Exit the loop since we found the lever
                }
            }
        }
    }
}
