using UnityEngine;

public abstract class CollectibleItemBase : MonoBehaviour {
    [SerializeField] protected InventoryItemType itemType;
    [SerializeField] protected int itemQuantity;

    private bool allowCollect;

    private void OnEnable() {
        PlayerCharacterUnit.OnPlayerSpawn += OnPlayerSpawn;
    }

    private void OnDisable() {
        PlayerCharacterUnit.OnPlayerSpawn -= OnPlayerSpawn;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (allowCollect && other.CompareTag(GameTags.Player)) {
            CollectItem();
        }
    }

    protected virtual void CollectItem() {
        InventoryManager.Instance.AddItem(itemType, itemQuantity);
        SetAllowCollect(false);
        Destroy(gameObject);
    }

    private void OnPlayerSpawn(Transform playerTransform) {
        SetAllowCollect(true);
    }

    public void SetAllowCollect(bool allow) {
        allowCollect = allow;
    }
}