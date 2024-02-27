using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputEvents {
    private bool invokePlayerActions = true;

    public Action<InputAction.CallbackContext> onAbilityUsed;
    public Action onInteract;
    public Action<Vector2> onMovePressed;
    public Action onQuestJournalToggled;

    public void MovePressed(Vector2 direction) {
        if (invokePlayerActions) {
            onMovePressed?.Invoke(direction);
        } else {
            onMovePressed?.Invoke(Vector2.zero);
        }
    }

    public void Interact() {
        if (invokePlayerActions) {
            onInteract?.Invoke();
        }
    }

    public void AbilityUsed(InputAction.CallbackContext context) {
        if (invokePlayerActions) {
            onAbilityUsed?.Invoke(context);
        }
    }

    public void QuestJournalToggled() {
        if (invokePlayerActions) {
            onQuestJournalToggled?.Invoke();
        }
    }

    public void TogglePlayerActions(bool toggle) {
        invokePlayerActions = toggle;
    }
}