using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Wall Hack")]
public class WallHackAbilitySO : AbilityBaseSO {
    private CapsuleCollider2D capsuleCollider2D;

    public override void Reset(GameObject gameObject) {
        capsuleCollider2D.enabled = true;
    }

    public override void Activate(GameObject gameObject) {
        if (capsuleCollider2D == null) {
            capsuleCollider2D = gameObject.GetComponent<CapsuleCollider2D>();
        }

        capsuleCollider2D.enabled = false;
    }
}