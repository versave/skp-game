public class FetchCokePersonalQuestStep : SimpleFetchQuestStep {
    protected override void OnItemAdded(InventoryItemType itemType, int amount) {
        if (itemType == fetchItemType) {
            FinishQuestStep();
            GameEventsManager.Instance.questEvents.FinishQuest(questId);
        }
    }
}