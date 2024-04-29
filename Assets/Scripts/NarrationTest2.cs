using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NarrationTest2 : MonoBehaviour
{
    public GameObject[] texts; // Array to hold all the text GameObjects
    public float[] textDurations; // Array to hold the duration for each text
    public float[] textDelays; // Array to hold the delay for each text
    public AudioClip preTextAudioClip; // Audio clip to play before showing the first text
    public AudioSource audioSource; // Reference to the AudioSource component
    public float audioTransitionDuration = 1f; // Duration of the transition between audio clip and first text

    private int currentIndex = -1; // Index to keep track of the current text being displayed, initialized to -1
    private bool audioPlayed = false; // Flag to track if the pre-text audio clip has been played
    private bool audioTriggered = false; // Flag to track if the audio has been triggered for the current collider
    private bool activated = false; // Flag to track whether this collider trigger has been activated before
    private saveState saveStateScript;

    public void Start()
    {
        saveStateScript = GameObject.Find("LevelSaveState").GetComponent<saveState>();
    }

    // OnTriggerEnter is called when the Collider other enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        Scene scene = SceneManager.GetActiveScene();
        // Check if the collider belongs to the player and if this collider trigger has not been activated before
        if (other.CompareTag("Player") && !activated  && !saveStateScript.levelOnePass)
        {
            // Start the dialogue
            activated = true;
            StartCoroutine(PlayAudioAndShowNextText());
        }

        else if(other.CompareTag("Player") && !activated && scene.name == "Observatory")
        {
            activated = true;
            StartCoroutine(PlayAudioAndShowNextText());
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
