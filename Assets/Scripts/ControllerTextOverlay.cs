using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class ControllerTextOverlay : MonoBehaviour
{
    public TextMeshProUGUI controllerText;
    public InputActionReference[] finishActions; // Specify the actions to finish the function
    public float fadeDuration = 2f;

    private bool functionCompleted = false;

    private IEnumerator FadeOutText()
    {
        // Get the initial color of the text
        Color initialColor = controllerText.color;

        // Set the alpha value to 0
        Color targetColor = new Color(initialColor.r, initialColor.g, initialColor.b, 0);

        // Calculate the rate of change per frame
        float rate = 1 / fadeDuration;

        // Loop until the text completely fades out
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime * rate)
        {
            // Interpolate the color from initial to target
            controllerText.color = Color.Lerp(initialColor, targetColor, t);
            yield return null;
        }

        // Ensure the final color is set
        controllerText.color = targetColor;

        // Deactivate the text game object
        controllerText.gameObject.SetActive(false);
    }

    private IEnumerator FadeInText()
    {
        // Get the initial color of the text
        Color initialColor = controllerText.color;

        // Set the alpha value to 1
        Color targetColor = new Color(initialColor.r, initialColor.g, initialColor.b, 1);

        // Calculate the rate of change per frame
        float rate = 1 / fadeDuration;

        // Loop until the text completely fades in
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime * rate)
        {
            // Interpolate the color from initial to target
            controllerText.color = Color.Lerp(initialColor, targetColor, t);
            yield return null;
        }

        // Ensure the final color is set
        controllerText.color = targetColor;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !functionCompleted)
        {
            controllerText.gameObject.SetActive(true);
            StartCoroutine(FadeInText());
        }
    }

    private void Update()
    {
        // Check if the function is completed by checking if any of the finish actions are triggered
        if (!functionCompleted)
        {
            foreach (InputActionReference action in finishActions)
            {
                if (action.action.triggered)
                {
                    functionCompleted = true;
                    StartCoroutine(FadeOutText());
                    break;
                }
            }
        }
    }
}

