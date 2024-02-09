using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Invisibility")]
public class InvisibilityAbility : AbilityBase {
    [SerializeField] private float fadeDuration = 1.0f;
    private InvisibilityHandler invisibilityHandler;
    private SpriteRenderer spriteRenderer;

    public override void Reset(GameObject gameObject) {
        invisibilityHandler.StartFadeIn(spriteRenderer, fadeDuration);
    }

    public override void Activate(GameObject gameObject) {
        if (spriteRenderer == null) {
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        }

        if (invisibilityHandler == null) {
            invisibilityHandler = gameObject.AddComponent<InvisibilityHandler>();
        }

        invisibilityHandler.StartFadeOut(spriteRenderer, fadeDuration);
    }
}