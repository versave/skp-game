using UnityEngine;

public class CollectCoinsQuestStep : QuestStepBase {
    private readonly int coinsToCollect = 5;
    private int coinsCollected;

    private void OnEnable() {
        GameEventsManager.Instance.goldEvents.onGoldGainedEvent += OnCoinCollected;
    }

    private void OnDisable() {
        GameEventsManager.Instance.goldEvents.onGoldGainedEvent -= OnCoinCollected;
    }

    private void OnCoinCollected(int gold) {
        if (coinsCollected < coinsToCollect) {
            coinsCollected++;
        }

        if (coinsCollected >= coinsToCollect) {
            Debug.Log("Quest step completed!");
            FinishQuestStep();
        }
    }
}