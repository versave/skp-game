using UnityEngine;

public class CollectibleItemBase : MonoBehaviour {
    [SerializeField] private InventoryItemType itemType = InventoryItemType.Coke;
    [SerializeField] private int itemQuantity;

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