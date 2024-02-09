using UnityEngine;

public abstract class UnitBase : MonoBehaviour {
    public UniqueCharacterId characterId;
    public Animator animator;
    public Character character;

    protected virtual void AssignCharacterValues() {
        gameObject.name = character.displayName;
        gameObject.transform.position = character.spawnPosition;

        characterId = character.characterId;
        animator.runtimeAnimatorController = character.animatorController;
    }
}