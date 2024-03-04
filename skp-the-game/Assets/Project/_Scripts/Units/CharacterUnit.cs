using UnityEngine;

public class CharacterUnit : UnitBase {
    [SerializeField] private UnitInteractionHandler interactionHandler;

    private void Start() {
        SelfDestroyOnPlayerPicked();
        AssignCharacterValues();
        interactionHandler.SetCharacter(characterSo);
    }

    private void OnParticleTrigger() {
        Debug.Log("Particle Triggered");
    }

    protected override void AssignCharacterValues() {
        base.AssignCharacterValues();
        SetQuestGiver();
    }

    private void SetQuestGiver() {
        bool hasQuestGiver = characterSo.questGiverInfo != null;
        bool isPlayerCharacter = GameManager.Instance.selectedCharacterId == characterSo.characterId;

        if (hasQuestGiver && !isPlayerCharacter) {
            EnableQuestPoint(characterSo.questGiverInfo);
        }
    }
}