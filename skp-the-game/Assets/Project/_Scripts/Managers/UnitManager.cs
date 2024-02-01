using UnityEngine;

public class UnitManager : MonoBehaviour {
    [SerializeField] private GameObject characterPrefab;
    private UniqueCharacterId playerId;

    private void Start() {
        playerId = GameManager.Instance.selectedCharacterId;

        SpawnPlayer();
    }

    private void SpawnPlayer() {
        Transform spawnPoint = transform;
        Character playerCharacter = ResourceSystem.Instance.GetCharacter(playerId);

        spawnPoint.position = playerCharacter.spawnPosition;

        GameObject playerObj = Instantiate(characterPrefab, spawnPoint);
        Animator playerObjAnimator = playerObj.GetComponent<Animator>();
        CharacterUnit playerObjCharacterUnit = playerObj.GetComponent<CharacterUnit>();
        AddRigidBodyComponent(playerObj);
        AddPlayerControllerComponent(playerObj);

        playerObj.tag = GameTags.Player;
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
}