using UnityEngine;

public class CollectGoldPersonalQuestStep : QuestStepBase {
    [SerializeField] private int goldToCollect = 10;
    private int goldCollected;

    private void OnEnable() {
        GameEventsManager.Instance.inventoryEvents.onItemAdded += OnItemAdded;
    }

    private void OnDisable() {
        GameEventsManager.Instance.inventoryEvents.onItemAdded -= OnItemAdded;
    }

    private void OnItemAdded(InventoryItemType itemType, int amount) {
        if (itemType != InventoryItemType.Gold) {
            return;
        }

        if (goldCollected < goldToCollect) {
            goldCollected++;
        }

        if (goldCollected >= goldToCollect) {
            FinishQuestStep();
            GameEventsManager.Instance.questEvents.FinishQuest(questId);
        }
    }
}