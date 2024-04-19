using System.Collections;
using UnityEngine;

public class NarrationTest2 : MonoBehaviour
{
    public GameObject[] texts; // Array to hold all the text GameObjects
    public float[] textDurations; // Array to hold the duration for each text
    public AudioClip preTextAudioClip; // Audio clip to play before showing the first text
    public AudioSource audioSource; // Reference to the AudioSource component
    public float audioTransitionDuration = 1f; // Duration of the transition between audio clip and first text
    public float textDelay = 0f; // Delay before starting to display text after collider trigger

    private int currentIndex = -1; // Index to keep track of the current text being displayed, initialized to -1
    private bool audioPlayed = false; // Flag to track if the pre-text audio clip has been played
    private bool audioTriggered = false; // Flag to track if the audio has been triggered for the current collider

    // Flag to track whether this collider trigger has been activated before
    private bool activated = false;

    // OnTriggerEnter is called when the Collider other enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player and if this collider trigger has not been activated before
        if (other.CompareTag("Player") && !activated)
        {
            // Mark this collider trigger as activated
            activated = true;

            // Start the dialogue
            StartCoroutine(PlayAudioAndShowNextText());
        }
    }

    private IEnumerator PlayAudioAndShowNextText()
    {
        // Play the pre-text audio clip with a transition duration if it hasn't been played yet for this collider trigger
        if (preTextAudioClip != null && audioSource != null && !audioPlayed)
        {
            // Start playing the audio clip
            audioSource.PlayOneShot(preTextAudioClip);
            audioPlayed = true; // Set the flag to indicate that the audio has been played
            audioTriggered = true; // Set the flag to indicate that the audio has been triggered for this collider

            // Wait for the transition duration before showing the first text
            yield return new WaitForSeconds(audioTransitionDuration);
        }

        // Show the first text after playing the audio clip or without it
        ShowNextText();
    }

    private void ShowNextText()
    {
        // Increment the index
        currentIndex++;

        // Activate the next text element
        texts[currentIndex].SetActive(true);

        // Wait for the specified text duration
        StartCoroutine(DeactivateTextAfterDuration());
    }

    private IEnumerator DeactivateTextAfterDuration()
    {
        // Wait for the specified text duration
        yield return new WaitForSeconds(textDurations[currentIndex]);

        // Deactivate the current text element
        texts[currentIndex].SetActive(false);

        // Check if this is the last text element
        if (currentIndex < texts.Length - 1)
        {
            // Automatically transition to the next text after the text duration
            yield return new WaitForSeconds(audioTransitionDuration); // Wait for the transition duration
            ShowNextText();
        }
        else
        {
            // Reset flags and static variable when the sequence is finished
            audioPlayed = false;
            audioTriggered = false;
            currentIndex = -1;
        }
    }
}
