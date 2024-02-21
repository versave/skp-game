using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class InputManager : MonoBehaviour {
    public void MovePressed(InputAction.CallbackContext context) {
        if (context.performed || context.canceled) {
            GameEventsManager.Instance.inputEvents.MovePressed(context.ReadValue<Vector2>());
        }
    }

    public void InteractPressed(InputAction.CallbackContext context) {
        if (context.started) {
            GameEventsManager.Instance.inputEvents.Interact();
        }
    }

    public void AbilityUsed(InputAction.CallbackContext context) {
        GameEventsManager.Instance.inputEvents.AbilityUsed(context);
    }

    public void QuestJournalToggled(InputAction.CallbackContext context) {
        if (context.started) {
            GameEventsManager.Instance.inputEvents.QuestJournalToggled();
        }
    }
}