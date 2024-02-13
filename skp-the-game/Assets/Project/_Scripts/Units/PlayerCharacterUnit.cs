using System;
using UnityEngine;

public class PlayerCharacterUnit : UnitBase {
    public static Action<Transform> OnPlayerSpawn;
    [SerializeField] private AbilityController abilityController;

    private void Start() {
        AssignCharacterValues();
        OnPlayerSpawn?.Invoke(transform);
    }

    protected override void AssignCharacterValues() {
        base.AssignCharacterValues();

        gameObject.name = GameTags.Player;
        gameObject.transform.position = characterSo.spawnPosition;
        abilityController.ability = characterSo.ability;
    }
}