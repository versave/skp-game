using UnityEngine;
using UnityEngine.InputSystem;

public class AbilityController : MonoBehaviour {
    public AbilityBase ability;

    private InputAction.CallbackContext abilityAction;

    private AbilityState abilityState = AbilityState.Ready;

    private float cooldownSeconds;
    private float durationSeconds;

    private void Update() {
        HandleAbilityState();
    }

    private void OnEnable() {
        GameEventsManager.Instance.inputEvents.onAbilityUsed += SetAbilityAction;
    }

    private void OnDisable() {
        GameEventsManager.Instance.inputEvents.onAbilityUsed -= SetAbilityAction;
    }

    private void HandleAbilityState() {
        switch (abilityState) {
            case AbilityState.Ready:
                if (abilityAction.performed) {
                    ability.Activate(gameObject);
                    abilityState = AbilityState.Active;
                    durationSeconds = ability.durationSeconds;
                }

                break;
            case AbilityState.Active:
                if (durationSeconds > 0) {
                    durationSeconds -= Time.deltaTime;
                } else {
                    abilityState = AbilityState.Cooldown;
                    cooldownSeconds = ability.cooldownSeconds;
                    ability.Reset(gameObject);
                }

                break;
            case AbilityState.Cooldown:
                if (cooldownSeconds > 0) {
                    cooldownSeconds -= Time.deltaTime;
                } else {
                    abilityState = AbilityState.Ready;
                }

                break;
        }
    }

    private void SetAbilityAction(InputAction.CallbackContext context) {
        abilityAction = context;
    }
}

internal enum AbilityState {
    Ready,
    Cooldown,
    Active
}