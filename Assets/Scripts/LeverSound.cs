using UnityEngine;
using UnityEngine.InputSystem;

public class LeverInteraction : MonoBehaviour
{
    public string leverTag = "lever"; // Tag of the lever object
    public AudioClip interactionSound; // Sound to play on interaction
    public AudioSource audioSource; // Reference to the AudioSource component

    private bool interactionOccurred = false; // Flag to track if interaction has occurred

    private void Start()
    {
        // Check if AudioSource is assigned
        if (audioSource == null)
        {
            Debug.LogWarning("AudioSource is not assigned to LeverInteraction script.");
        }
    }

    private void Update()
    {
        // Check if the interaction key is pressed and interaction hasn't occurred yet
        if (Keyboard.current.xKey.wasPressedThisFrame && !interactionOccurred)
        {
            // Check if player is colliding with an object tagged as "lever"
            Collider[] colliders = Physics.OverlapSphere(transform.position, 1f);
            foreach (var collider in colliders)
            {
                if (collider.CompareTag(leverTag))
                {
                    // Play interaction sound
                    if (audioSource != null && interactionSound != null)
                    {
                        audioSource.PlayOneShot(interactionSound);
                    }

                    // Set interaction flag to true
                    interactionOccurred = true;
                    break;
                }
            }
        }
    }
}
