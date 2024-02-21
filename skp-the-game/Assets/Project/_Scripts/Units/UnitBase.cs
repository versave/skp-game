using UnityEngine;

public abstract class UnitBase : MonoBehaviour {
    public UniqueCharacterId characterId;
    public Animator animator;
    public CharacterSO characterSo;
    public QuestPoint questPoint;

    protected virtual void AssignCharacterValues() {
        gameObject.name = characterSo.displayName;
        characterId = characterSo.characterId;
        animator.runtimeAnimatorController = characterSo.animatorController;
    }

    public void SelfDestroyOnPlayerPicked() {
        if (GameManager.Instance.selectedCharacterId == characterSo.characterId) {
            Destroy(gameObject);
        }
    }
}