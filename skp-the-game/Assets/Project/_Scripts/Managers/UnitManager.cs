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
        CharacterSO playerCharacterSo = ResourceSystem.Instance.GetCharacter(playerId);
        PlayerCharacterUnit playerObj = Instantiate(playerCharacterUnitPrefab, transform);
        playerObj.characterSo = playerCharacterSo;
    }

    private void SpawnNpcs() {
        foreach (CharacterSO character in ResourceSystem.Instance.charactersList) {
            if (character.characterId != playerId) {
                SpawnNpcCharacter(character);
            }
        }
    }

    private void SpawnNpcCharacter(CharacterSO characterSo) {
        CharacterUnit npcObj = Instantiate(characterPrefab, transform);
        npcObj.characterSo = characterSo;
    }
}