using System.Collections;
using UnityEngine;

public class NarrativeManager : MonoBehaviour
{
    public GameObject hiddenText;
    public GameObject shownText;
    public float textDuration = 5f; // Duration for how long the text stays active after being shown
    public float stayDuration = 5f; // Duration for how long the player stays in the collider trigger

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            shownText.SetActive(false);
            StartCoroutine(ShowTextAndDelay());
        }
    }

    private IEnumerator ShowTextAndDelay()
    {
        hiddenText.SetActive(true);
        yield return new WaitForSeconds(textDuration);

        // Wait for the specified stay duration
        yield return new WaitForSeconds(stayDuration);

        hiddenText.SetActive(false);
        gameObject.SetActive(false);
    }
}
