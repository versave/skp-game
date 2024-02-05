using System;
using UnityEngine;

public class PlayerCharacterUnit : UnitBase {
    public static Action<Transform> OnPlayerSpawn;
    public AbilityController abilityController;

    private void Start() {
        OnPlayerSpawn?.Invoke(transform);
    }
}