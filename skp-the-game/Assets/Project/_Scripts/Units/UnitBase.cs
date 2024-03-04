using UnityEngine;

public abstract class UnitBase : MonoBehaviour {
    public UniqueCharacterId characterId;
    public Animator animator;
    public CharacterSO characterSo;
    public QuestPoint questPoint;
    public AIMovement aiMovement;

    protected virtual void AssignCharacterValues() {
        gameObject.name = characterSo.displayName;
        characterId = characterSo.characterId;
        animator.runtimeAnimatorController = characterSo.animatorController;
    }

    protected void SelfDestroyOnPlayerPicked() {
        if (GameManager.Instance.selectedCharacterId == characterSo.characterId) {
            Destroy(gameObject);
        }
    }

    protected void EnableQuestPoint(QuestInfoSO questInfo) {
        questPoint.enabled = true;
        questPoint.SetQuestInfo(questInfo);
    }

    protected void SetAICharacterId() {
        aiMovement.characterId = characterSo.characterId;
    }
}