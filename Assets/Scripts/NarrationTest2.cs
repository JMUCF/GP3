using System.Collections;
using UnityEngine;

public class NarrationTest2 : MonoBehaviour
{
    public GameObject[] texts; // Array to hold all the text GameObjects
    public float[] textDurations; // Array to hold the duration for each text
    public float[] textDelays; // Array to hold the delay for each text
    public AudioClip preTextAudioClip; // Audio clip to play before showing the first text
    public AudioSource audioSource; // Reference to the AudioSource component
    public float audioTransitionDuration = 1f; // Duration of the transition between audio clip and first text

    private bool hasPlayed = false; // Flag to track if the narration sequence has already played

    // OnTriggerEnter is called when the Collider other enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player and if the narration sequence hasn't played yet
        if (other.CompareTag("Player") && !hasPlayed)
        {
            // Start the dialogue
            StartCoroutine(PlayAudioAndShowNextText());

            // Mark the narration sequence as played
            hasPlayed = true;
        }
    }

    private IEnumerator PlayAudioAndShowNextText()
    {
        // Play the pre-text audio clip with a transition duration if it hasn't been played yet for this collider trigger
        if (preTextAudioClip != null && audioSource != null)
        {
            // Start playing the audio clip
            audioSource.PlayOneShot(preTextAudioClip);

            // Wait for the transition duration before showing the first text
            yield return new WaitForSeconds(audioTransitionDuration);
        }

        // Show the text elements
        for (int i = 0; i < texts.Length; i++)
        {
            // Activate the text element with a delay
            yield return new WaitForSeconds(textDelays[i]);
            texts[i].SetActive(true);

            // Wait for the specified text duration
            yield return new WaitForSeconds(textDurations[i]);

            // Deactivate the text element
            texts[i].SetActive(false);
        }
    }
}
