using UnityEngine;

public class SimpleFetchQuestStep : QuestStepBase {
    [SerializeField] protected InventoryItemType fetchItemType;

    private void OnEnable() {
        GameEventsManager.Instance.inventoryEvents.onItemAdded += OnItemAdded;
    }

    private void OnDisable() {
        GameEventsManager.Instance.inventoryEvents.onItemAdded -= OnItemAdded;
    }

    protected virtual void OnItemAdded(InventoryItemType itemType, int amount) {
        if (itemType == fetchItemType) {
            FinishQuestStep();
        }
    }
}