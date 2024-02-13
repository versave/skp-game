using System;

public class InventoryEvents {
    public Action<InventoryItemType, int> onItemAdded;
    public Action<InventoryItemType, int> onItemRemoved;

    public void ItemAdded(InventoryItemType itemType, int amount) {
        onItemAdded?.Invoke(itemType, amount);
    }

    public void ItemRemoved(InventoryItemType itemType, int amount) {
        onItemRemoved?.Invoke(itemType, amount);
    }
}