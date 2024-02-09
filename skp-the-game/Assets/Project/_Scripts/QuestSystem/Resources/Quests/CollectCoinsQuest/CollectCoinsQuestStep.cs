using UnityEngine;

public class CollectCoinsQuestStep : QuestStep {
    private readonly int coinsToCollect = 5;
    private int coinsCollected;

    private void OnEnable() {
        GameEventsManager.Instance.GoldEvents.onGoldGainedEvent += OnCoinCollected;
    }

    private void OnDisable() {
        GameEventsManager.Instance.GoldEvents.onGoldGainedEvent -= OnCoinCollected;
    }

    private void OnCoinCollected(int gold) {
        if (coinsCollected < coinsToCollect) {
            coinsCollected++;
        }

        Debug.Log("Coins collected: " + coinsCollected);

        if (coinsCollected >= coinsToCollect) {
            Debug.Log("Quest step completed!");
            FinishQuestStep();
        }
    }
}