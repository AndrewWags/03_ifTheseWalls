using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CanvasGroup))]
public class CanvasGroupFader : MonoBehaviour
{
    CanvasGroup canvasGroup;

    CoroutineManager.Item fadeSequence = new CoroutineManager.Item();

    public MinMaxFloat alpha = new MinMaxFloat(0.0f, 1f, 0f);
    public float fadeDuration = 0.5f;

    public bool fadeOutOnAwake = false;

    public bool setsInteractability = true;

    public bool unscaledTime = true;

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        //if (fadeOutOnAwake) canvasGroup.alpha = 0f;
        if (fadeOutOnAwake)
        {
            canvasGroup.alpha = 0f;
            if (setsInteractability)
            {
                canvasGroup.interactable = false;
                canvasGroup.blocksRaycasts = false;
            }
        }
    }

    public void FadeInForDuration(float duration)
    {
        fadeSequence.value = FadeInForDurationSequence(duration);
    }

    public void FadeIn()
    {
        fadeSequence.value = FadeInSequence();
    }

    public void FadeOut()
    {
        //Debug.Log("Fade out || " + Time.time);
        fadeSequence.value = FadeOutSequence();
    }

    public void SetToMax()
    {
        canvasGroup.alpha = alpha.max;
    }

    public void SetToMin()
    {
        canvasGroup.alpha = alpha.min;
    }

    IEnumerator FadeInSequence()
    {
        if (setsInteractability)
        {
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }

        float timeElapsed = 0f;

        alpha.value = canvasGroup.alpha;
        float duration = fadeDuration * (1 - alpha.percentage);

        float originalAlpha = canvasGroup.alpha;

        while (timeElapsed < duration)
        {
            timeElapsed += (unscaledTime ? Time.unscaledDeltaTime : Time.deltaTime);
            alpha.value = originalAlpha + (timeElapsed / duration * (1 - originalAlpha));

            canvasGroup.alpha = alpha.value;

            yield return null;
        }
    }

    IEnumerator FadeOutSequence()
    {
        if (setsInteractability)
        {
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }

        float timeElapsed = 0f;

        alpha.value = canvasGroup.alpha;
        float duration = fadeDuration * alpha.percentage;

        float originalAlpha = canvasGroup.alpha;

        while (timeElapsed < duration)
        {
            timeElapsed += (unscaledTime ? Time.unscaledDeltaTime : Time.deltaTime);

            alpha.value = originalAlpha - (timeElapsed / duration);

            canvasGroup.alpha = alpha.value;

            yield return null;
        }
    }

    IEnumerator FadeInForDurationSequence(float duration)
    {
        yield return FadeInSequence();

        yield return new WaitForSeconds(duration);

        FadeOut();
    }
}
