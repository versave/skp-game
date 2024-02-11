using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputEvents {
    public Action<InputAction.CallbackContext> onAbilityUsed;
    public Action onInteract;
    public Action<Vector2> onMovePressed;

    public void MovePressed(Vector2 direction) {
        onMovePressed?.Invoke(direction);
    }

    public void Interact() {
        onInteract?.Invoke();
    }

    public void AbilityUsed(InputAction.CallbackContext context) {
        onAbilityUsed?.Invoke(context);
    }
}