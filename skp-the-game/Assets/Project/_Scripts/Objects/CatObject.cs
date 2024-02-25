using UnityEngine;

public class CatObject : MonoBehaviour {
    [SerializeField] private ObjectType objectType;
    [SerializeField] private CircleCollider2D triggerCircleCollider;
    [SerializeField] private bool disableTriggerOnEnter;

    private bool triggerEnabled = true;

    private void OnTriggerEnter2D(Collider2D other) {
        if (!triggerEnabled) {
            return;
        }

        if (other.CompareTag(GameTags.Player)) {
            PlayerEnterTrigger();
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (disableTriggerOnEnter) {
            return;
        }

        if (other.CompareTag(GameTags.Player)) {
            PlayerExitTrigger();
        }
    }

    private void PlayerEnterTrigger() {
        GameEventsManager.Instance.objectEvents.EnterObjectRange(objectType);

        if (disableTriggerOnEnter) {
            triggerCircleCollider.enabled = false;
            triggerEnabled = false;
        }
    }

    private void PlayerExitTrigger() {
        GameEventsManager.Instance.objectEvents.ExitObjectRange(objectType);
    }
}