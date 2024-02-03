using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Speed Boost")]
public class SpeedBoostAbility : AbilityBase {
    [SerializeField] private float speedBoost;
    private PlayerController playerController;

    public override void Reset(GameObject gameObject) {
        playerController.moveSpeed -= speedBoost;
    }

    public override void Activate(GameObject gameObject) {
        if (playerController == null) {
            playerController = gameObject.GetComponent<PlayerController>();
        }

        playerController.moveSpeed += speedBoost;
    }
}