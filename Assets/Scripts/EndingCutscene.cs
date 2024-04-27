using System.Collections;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingCutscene : MonoBehaviour
{
    public GameObject circleThing;
    public GameObject pod;
    public GameObject podLid;
    public CinemachineVirtualCamera virtualCamera;
    public GameObject player;

    public Image fadeImage;
    public float fadeDuration = 1.0f;

    void Start()
    {
        StartFade();
    }

    public void StartFade()
    {
        StartCoroutine(StartSequence());
    }

    IEnumerator StartSequence()
    {
        StartCoroutine(CloseLid(-107f, 2f));

        yield return new WaitForSeconds(3f);
        player.SetActive(false);

        // Screen shake
        StartCoroutine(ScreenShake(0.2f, 0.25f));

        // Move circleThing
        StartCoroutine(MoveCircleThing(100f, 3f));

        yield return new WaitForSeconds(2f); // Wait for 3 seconds

        // Move pod
        StartCoroutine(ScreenShake(0.1f, 1f));
        StartCoroutine(MovePod(50f, 3f));

        yield return new WaitForSeconds(2.75f); // Wait for 3 seconds

        StartCoroutine(FadeCanvas(true));

    }

    IEnumerator MoveCircleThing(float distance, float duration)
    {
        Vector3 initialPosition = circleThing.transform.position;
        Vector3 targetPosition = initialPosition + new Vector3(0, 0, distance);
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            circleThing.transform.position = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Make sure circleThing reaches the exact target position
        circleThing.transform.position = targetPosition;
    }

    IEnumerator MovePod(float distance, float duration)
    {
        Vector3 initialPosition = pod.transform.position;
        Vector3 targetPosition = initialPosition + new Vector3(0, 0, distance);
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            pod.transform.position = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Make sure pod reaches the exact target position
        pod.transform.position = targetPosition;
    }

    IEnumerator ScreenShake(float magnitude, float duration)
    {
        Vector3 originalPos = virtualCamera.transform.localPosition;
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            virtualCamera.transform.localPosition = originalPos + new Vector3(x, y, 0);

            elapsed += Time.deltaTime;

            yield return null;
        }

        virtualCamera.transform.localPosition = originalPos;
    }

    IEnumerator FadeCanvas(bool fadeIn)
    {
        Color targetColor = fadeIn ? Color.black : Color.clear;
        Color currentColor = fadeImage.color;
        float timer = 0;

        while (timer < fadeDuration)
        {
            fadeImage.color = Color.Lerp(currentColor, targetColor, timer / fadeDuration);
            timer += Time.deltaTime;
            yield return null;
        }

        fadeImage.color = targetColor;
        SceneManager.LoadScene("GameOver");
    }

    IEnumerator CloseLid(float targetRotation, float duration)
{
    Quaternion initialRotation = podLid.transform.rotation;
    Quaternion targetRotationQuat = Quaternion.Euler(targetRotation, initialRotation.eulerAngles.y, initialRotation.eulerAngles.z);
    float elapsedTime = 0f;

    while (elapsedTime < duration)
    {
        podLid.transform.rotation = Quaternion.Lerp(initialRotation, targetRotationQuat, elapsedTime / duration);
        elapsedTime += Time.deltaTime;
        yield return null;
    }

    // Make sure podLid reaches the exact target rotation
    podLid.transform.rotation = targetRotationQuat;
}

}
