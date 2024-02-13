using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager> {
    private readonly Dictionary<InventoryItemType, int> items = new();

    public void AddItem(InventoryItemType itemType, int amount) {
        if (items.ContainsKey(itemType)) {
            items[itemType] += amount;
        } else {
            items.Add(itemType, amount);
        }

        GameEventsManager.Instance.inventoryEvents.ItemAdded(itemType, amount);
    }

    public void RemoveItem(InventoryItemType itemType, int amount) {
        if (items.ContainsKey(itemType)) {
            items[itemType] -= amount;

            if (items[itemType] <= 0) {
                items.Remove(itemType);
            }

            GameEventsManager.Instance.inventoryEvents.ItemRemoved(itemType, amount);
        } else {
            Debug.LogWarning("Item " + itemType + " not found in inventory.");
        }
    }


    public bool HasItem(InventoryItemType itemType) {
        return items.ContainsKey(itemType);
    }


    public int GetItemQuantity(InventoryItemType itemType) {
        if (items.ContainsKey(itemType)) {
            return items[itemType];
        }

        return 0;
    }
}