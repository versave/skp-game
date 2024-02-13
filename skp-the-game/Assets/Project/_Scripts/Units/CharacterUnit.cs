using UnityEngine;

public class CharacterUnit : UnitBase {
    private bool isPlayerInTrigger;

    private void Start() {
        SelfDestroyOnPlayerPicked();
        AssignCharacterValues();
    }

    private void OnEnable() {
        GameEventsManager.Instance.inputEvents.onInteract += OnPlayerInteract;
    }

    private void OnDisable() {
        GameEventsManager.Instance.inputEvents.onInteract -= OnPlayerInteract;
    }

    private void OnParticleTrigger() {
        Debug.Log("Particle Triggered");
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
}