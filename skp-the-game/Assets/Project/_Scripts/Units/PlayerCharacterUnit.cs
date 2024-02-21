using System;
using UnityEngine;

public class PlayerCharacterUnit : UnitBase {
    public static Action<Transform> OnPlayerSpawn;
    [SerializeField] private AbilityController abilityController;

    private void Start() {
        AssignCharacterValues();
        StartPersonalQuest();
        OnPlayerSpawn?.Invoke(transform);
    }

    protected override void AssignCharacterValues() {
        base.AssignCharacterValues();

        gameObject.name = GameTags.Player;
        gameObject.transform.position = characterSo.spawnPosition;
        abilityController.ability = characterSo.ability;

        SetPersonalQuest();
    }

    private void SetPersonalQuest() {
        bool hasPersonalGiver = characterSo.personalQuestInfo != null;
        bool isPlayerCharacter = GameManager.Instance.selectedCharacterId == characterSo.characterId;

        if (hasPersonalGiver && isPlayerCharacter) {
            questPoint.enabled = true;
            questPoint.questInfoForPoint = characterSo.personalQuestInfo;
        }
    }

    private void StartPersonalQuest() {
        if (characterSo.personalQuestInfo != null) {
            GameEventsManager.Instance.questEvents.StartQuest(characterSo.personalQuestInfo.id);
        }
    }
}