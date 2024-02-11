using System;
using UnityEngine;

public class GoldEvents {
    public Action<int> onGoldGainedEvent;

    public void GoldGained(int gold) {
        onGoldGainedEvent?.Invoke(gold);
    }

    public void RewardGold(int gold) {
        Debug.Log("Rewarding " + gold + " gold for quest completion!");
    }
}