using UnityEngine;

public class SimpleFetchQuestStep : QuestStepBase {
    [SerializeField] private InventoryItemType fetchItemType;

    private void OnEnable() {
        GameEventsManager.Instance.inventoryEvents.onItemAdded += OnItemAdded;
    }

    private void OnDisable() {
        GameEventsManager.Instance.inventoryEvents.onItemAdded -= OnItemAdded;
    }

    private void OnItemAdded(InventoryItemType itemType, int amount) {
        if (itemType == fetchItemType) {
            FinishQuestStep();
        }
    }
}