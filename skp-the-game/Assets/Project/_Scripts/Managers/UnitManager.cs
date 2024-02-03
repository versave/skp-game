using UnityEngine;

public class UnitManager : MonoBehaviour {
    [SerializeField] private PlayerCharacterUnit playerCharacterUnitPrefab;
    [SerializeField] private CharacterUnit characterPrefab;
    private UniqueCharacterId playerId;

    private void Start() {
        playerId = GameManager.Instance.selectedCharacterId;

        SpawnPlayer();
        SpawnNpcs();
    }

    private void SpawnPlayer() {
        Character playerCharacter = ResourceSystem.Instance.GetCharacter(playerId);
        PlayerCharacterUnit playerObj = Instantiate(playerCharacterUnitPrefab, transform);
        Animator playerObjAnimator = playerObj.animator;

        playerObj.name = "Player";
        playerObj.tag = GameTags.PLAYER;
        playerObj.characterId = playerCharacter.characterId;
        playerObj.transform.position = playerCharacter.spawnPosition;
        playerObjAnimator.runtimeAnimatorController = playerCharacter.animatorController;
    }

    private void SpawnNpcs() {
        foreach (Character character in ResourceSystem.Instance.characters) {
            if (character.characterId != playerId) {
                SpawnNpcCharacter(character);
            }
        }
    }

    private void SpawnNpcCharacter(Character character) {
        CharacterUnit npcObj = Instantiate(characterPrefab, transform);
        Animator npcObjAnimator = npcObj.animator;

        npcObj.name = character.displayName;
        npcObj.tag = GameTags.NPC;
        npcObj.characterId = character.characterId;
        npcObj.transform.position = character.spawnPosition;
        npcObjAnimator.runtimeAnimatorController = character.animatorController;
    }
}