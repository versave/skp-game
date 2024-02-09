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
        playerObj.character = playerCharacter;
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
        npcObj.character = character;
    }
}