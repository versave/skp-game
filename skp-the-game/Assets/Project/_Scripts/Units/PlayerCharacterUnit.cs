using System;
using UnityEngine;

public class PlayerCharacterUnit : UnitBase {
    public static Action<Transform> OnPlayerSpawn;

    private void Start() {
        OnPlayerSpawn?.Invoke(transform);
    }
}