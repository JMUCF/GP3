using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeToBlack : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 1.0f;

    void OnTriggerEnter()
    {
        StartFade();
    }
    public void StartFade()
    {
        StartCoroutine(FadeCanvas(true));
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
    }
}
