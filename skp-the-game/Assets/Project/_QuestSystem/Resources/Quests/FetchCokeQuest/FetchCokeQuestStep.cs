public class FetchCokeQuestStep : QuestStepBase {
    private void OnEnable() {
        GameEventsManager.Instance.inventoryEvents.onItemAdded += OnItemAdded;
    }

    private void OnDisable() {
        GameEventsManager.Instance.inventoryEvents.onItemAdded -= OnItemAdded;
    }

    private void OnItemAdded(InventoryItemType itemType, int amount) {
        if (itemType == InventoryItemType.Coke) {
            FinishQuestStep();
        }
    }
}