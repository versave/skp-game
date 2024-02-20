using UnityEngine;

public abstract class CollectibleItemBase : MonoBehaviour {
    [SerializeField] protected InventoryItemType itemType;
    [SerializeField] protected int itemQuantity;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag(GameTags.Player)) {
            CollectItem();
        }
    }

    protected virtual void CollectItem() {
        InventoryManager.Instance.AddItem(itemType, itemQuantity);
        Destroy(gameObject);
    }
}