using System.Collections;
using UnityEngine;

public class NarrationTest2 : MonoBehaviour
{
    public GameObject[] texts; // Array to hold all the text GameObjects
    public float[] textDurations; // Array to hold the duration for each text
    public AudioClip preTextAudioClip; // Audio clip to play before showing the first text
    public AudioSource audioSource; // Reference to the AudioSource component
    public float audioTransitionDuration = 1f; // Duration of the transition between audio clip and first text

    private int currentIndex = -1; // Index to keep track of the current text being displayed, initialized to -1
    private bool dialogueStarted = false; // Flag to track if the dialogue has started

    // OnTriggerEnter is called when the Collider other enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player and if the dialogue has not started yet
        if (other.CompareTag("Player") && !dialogueStarted)
        {
            // Start the dialogue
            dialogueStarted = true;
            StartCoroutine(PlayAudioAndShowNextText());
        }
    }

    private IEnumerator PlayAudioAndShowNextText()
    {
        // Play the pre-text audio clip with a transition duration
        if (preTextAudioClip != null && audioSource != null)
        {
            // Start playing the audio clip
            audioSource.PlayOneShot(preTextAudioClip);

            // Wait for the transition duration before showing the first text
            yield return new WaitForSeconds(audioTransitionDuration);
        }

        // Show the first text after playing the audio clip
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
    }

    // Start is called before the first frame update
    private void Start()
    {
        // Deactivate all text elements at the start
        foreach (GameObject text in texts)
        {
            text.SetActive(false);
        }
    }
}
