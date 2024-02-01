using UnityEngine;

public class UnitManager : MonoBehaviour {
    [SerializeField] private GameObject characterPrefab;
    private UniqueCharacterId playerId;

    private void Start() {
        playerId = GameManager.Instance.selectedCharacterId;

        SpawnPlayer();
        SpawnNpcs();
    }

    private void SpawnPlayer() {
        Character playerCharacter = ResourceSystem.Instance.GetCharacter(playerId);
        GameObject playerObj = Instantiate(characterPrefab, transform);
        Animator playerObjAnimator = playerObj.GetComponent<Animator>();
        CharacterUnit playerObjCharacterUnit = playerObj.GetComponent<CharacterUnit>();
        AddRigidBodyComponent(playerObj);
        AddPlayerControllerComponent(playerObj);

        playerObj.name = "Player";
        playerObj.tag = GameTags.PLAYER;
        playerObj.transform.position = playerCharacter.spawnPosition;
        playerObjAnimator.runtimeAnimatorController = playerCharacter.animatorController;
        playerObjCharacterUnit.characterId = playerCharacter.characterId;
    }

    private void AddRigidBodyComponent(GameObject gameObject) {
        Rigidbody2D rigidBody = gameObject.AddComponent<Rigidbody2D>();
        rigidBody.gravityScale = 0;
        rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private void AddPlayerControllerComponent(GameObject gameObject) {
        PlayerController playerController = gameObject.AddComponent<PlayerController>();
    }

    private void SpawnNpcs() {
        foreach (Character character in ResourceSystem.Instance.characters) {
            if (character.characterId != playerId) {
                SpawnNpcCharacter(character);
            }
        }
    }

    private void SpawnNpcCharacter(Character character) {
        GameObject npcObj = Instantiate(characterPrefab, transform);
        Animator npcObjAnimator = npcObj.GetComponent<Animator>();
        CharacterUnit npcObjCharacterUnit = npcObj.GetComponent<CharacterUnit>();

        npcObj.name = character.displayName;
        npcObj.tag = GameTags.NPC;
        npcObj.transform.position = character.spawnPosition;
        npcObjAnimator.runtimeAnimatorController = character.animatorController;
        npcObjCharacterUnit.characterId = character.characterId;
    }
}