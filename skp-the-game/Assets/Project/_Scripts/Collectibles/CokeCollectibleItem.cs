using UnityEngine;

public class CokeCollectibleItem : CollectibleItemBase {
    [SerializeField] private int requiredGold;

    protected override void CollectItem() {
        int playerGold = InventoryManager.Instance.GetItemQuantity(InventoryItemType.Gold);

        if (playerGold >= requiredGold) {
            base.CollectItem();
            InventoryManager.Instance.RemoveItem(InventoryItemType.Gold, requiredGold);
        }
    }
}