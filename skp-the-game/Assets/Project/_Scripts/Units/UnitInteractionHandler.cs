using UnityEngine;

public class UnitInteractionHandler : MonoBehaviour {
    private CharacterSO characterSo;
    private bool isPlayerInTrigger;

    private void OnEnable() {
        GameEventsManager.Instance.inputEvents.onInteract += OnPlayerInteract;
    }

    private void OnDisable() {
        GameEventsManager.Instance.inputEvents.onInteract -= OnPlayerInteract;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag(GameTags.Player)) {
            isPlayerInTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag(GameTags.Player)) {
            isPlayerInTrigger = false;
        }
    }

    private void OnPlayerInteract() {
        if (isPlayerInTrigger) {
            GameEventsManager.Instance.dialogueEvents.InitiateDialogue(characterSo);
        }
    }

    public void SetCharacter(CharacterSO character) {
        characterSo = character;
    }
}