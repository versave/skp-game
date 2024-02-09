using UnityEngine;

public class CharacterUnit : UnitBase {
    private void Start() {
        AssignCharacterValues();
    }

    private void OnParticleTrigger() {
        Debug.Log("Particle Triggered");
    }
}