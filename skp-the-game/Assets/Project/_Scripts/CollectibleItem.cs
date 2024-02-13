using UnityEngine;

public class CollectibleItem : MonoBehaviour {
    [SerializeField] private InventoryItemType itemType;
    [SerializeField] private int itemQuantity;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag(GameTags.Player)) {
            CollectItem();
        }
    }

    private void CollectItem() {
        InventoryManager.Instance.AddItem(itemType, itemQuantity);
        Destroy(gameObject);
    }
}