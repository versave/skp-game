using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Force Push")]
public class ForcePushAbility : AbilityBase {
    [SerializeField] private GameObject abilityPrefab;
    private GameObject instance;

    public override void Reset(GameObject gameObject) {
        Destroy(instance);
    }

    public override void Activate(GameObject gameObject) {
        instance = Instantiate(abilityPrefab, gameObject.transform);
    }
}