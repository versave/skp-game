using UnityEngine;

public class UnitManager : MonoBehaviour {
    [SerializeField] private PlayerCharacterUnit playerCharacterUnitPrefab;

    private UniqueCharacterId playerId;

    private void Start() {
        playerId = GameManager.Instance.selectedCharacterId;
        SpawnPlayer();
    }

    private void SpawnPlayer() {
        CharacterSO playerCharacterSo = ResourceSystem.Instance.GetCharacter(playerId);
        PlayerCharacterUnit playerObj = Instantiate(playerCharacterUnitPrefab, transform);
        playerObj.characterSo = playerCharacterSo;
    }
}