using System.Collections;
using UnityEngine;

public class InvisibilityHandler : MonoBehaviour {
    private Coroutine currentCoroutine;

    public void StartFadeOut(SpriteRenderer spriteRenderer, float fadeDuration) {
        if (currentCoroutine != null) {
            StopCoroutine(currentCoroutine);
        }

        currentCoroutine = StartCoroutine(FadeOut(spriteRenderer, fadeDuration));
    }

    public void StartFadeIn(SpriteRenderer spriteRenderer, float fadeDuration) {
        if (currentCoroutine != null) {
            StopCoroutine(currentCoroutine);
        }

        currentCoroutine = StartCoroutine(FadeIn(spriteRenderer, fadeDuration));
    }

    private IEnumerator FadeOut(SpriteRenderer spriteRenderer, float fadeDuration) {
        float elapsedTime = 0f;
        Color startColor = spriteRenderer.color;

        while (elapsedTime < fadeDuration) {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);

            spriteRenderer.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        // Ensure it's completely invisible at the end
        spriteRenderer.color = new Color(startColor.r, startColor.g, startColor.b, 0f);
    }

    private IEnumerator FadeIn(SpriteRenderer spriteRenderer, float fadeDuration) {
        float elapsedTime = 0f;
        Color startColor = spriteRenderer.color;

        while (elapsedTime < fadeDuration) {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);

            spriteRenderer.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        // Ensure it's completely visible at the end
        spriteRenderer.color = new Color(startColor.r, startColor.g, startColor.b, 1f);
    }
}