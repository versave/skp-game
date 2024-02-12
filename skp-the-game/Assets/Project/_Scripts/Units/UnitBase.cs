using UnityEngine;

public abstract class UnitBase : MonoBehaviour {
    public UniqueCharacterId characterId;
    public Animator animator;
    public CharacterSO characterSo;
    public QuestPoint quest;

    protected virtual void AssignCharacterValues() {
        gameObject.name = characterSo.displayName;
        gameObject.transform.position = characterSo.spawnPosition;

        characterId = characterSo.characterId;
        animator.runtimeAnimatorController = characterSo.animatorController;

        if (characterSo.questInfo != null) {
            quest.enabled = true;
            quest.questInfoForPoint = characterSo.questInfo;
        }
    }
}