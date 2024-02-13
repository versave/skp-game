using System.Collections;
using UnityEngine;

public class ForcePushHandler : MonoBehaviour {
    [SerializeField] private float initialGrowthSpeed = 1f;
    [SerializeField] private float maxRadius = 1.5f;
    [SerializeField] private float accelerationRate = 0.5f;

    [SerializeField] private CircleCollider2D circleCollider;
    [SerializeField] private ParticleSystem particle;
    [SerializeField] private float fadeOutDuration = 0.3f;


    private readonly string pushedTag = GameTags.Npc;
    private float currentRadius;
    private float growthSpeed;
    private bool isFadingOut;

    private ParticleSystem.MainModule mainParticleModule;

    private void Start() {
        mainParticleModule = particle.main;
        currentRadius = circleCollider.radius;
        growthSpeed = initialGrowthSpeed;
        isFadingOut = false;
    }

    private void Update() {
        if (isFadingOut) {
            return;
        }

        IncreaseRadius();
        FadeOutParticle();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag(pushedTag)) {
            // Todo: Apply force to NPCs
            Debug.Log("Trigger activated at position: " + transform.position);
        }
    }

    private void IncreaseRadius() {
        growthSpeed += accelerationRate * Time.deltaTime;
        currentRadius = Mathf.Clamp(currentRadius + growthSpeed * Time.deltaTime, 0f, maxRadius);
        circleCollider.radius = currentRadius;
        // Increase the size of the particle system
        mainParticleModule.startSize = currentRadius * 2;
    }

    private void FadeOutParticle() {
        if (currentRadius < maxRadius) {
            return;
        }

        isFadingOut = true;
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut() {
        Color startColor = mainParticleModule.startColor.color;
        float elapsedTime = 0f;

        while (elapsedTime < fadeOutDuration) {
            float alpha =
                Mathf.Lerp(1f, 0f, 1f - Mathf.Pow(1f - elapsedTime / fadeOutDuration, 3f)); // Cubic ease-out function

            mainParticleModule.startColor = new Color(startColor.r, startColor.g, startColor.b, alpha);
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        // Disable the game object after fade-out
        gameObject.SetActive(false);
    }
}