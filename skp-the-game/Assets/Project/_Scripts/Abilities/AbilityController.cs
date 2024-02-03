using UnityEngine;
using UnityEngine.InputSystem;

public class AbilityController : MonoBehaviour {
    [SerializeField] private AbilityBase ability;
    private AbilityState abilityState = AbilityState.Ready;

    private float cooldownSeconds;
    private float durationSeconds;

    private InputAction fire;
    private PlayerInputActions playerControls;

    private void Awake() {
        playerControls = new PlayerInputActions();
        fire = playerControls.Player.Fire;
    }

    private void Update() {
        HandleAbilityState();
    }

    private void OnEnable() {
        fire.Enable();
    }

    private void OnDisable() {
        fire.Disable();
    }

    private void HandleAbilityState() {
        switch (abilityState) {
            case AbilityState.Ready:
                if (fire.triggered) {
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
}

internal enum AbilityState {
    Ready,
    Cooldown,
    Active
}