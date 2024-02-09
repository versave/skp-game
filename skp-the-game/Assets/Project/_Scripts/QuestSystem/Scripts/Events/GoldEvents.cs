using System;

public class GoldEvents {
    public Action<int> onGoldGainedEvent;

    public void GoldGained(int gold) {
        onGoldGainedEvent?.Invoke(gold);
    }
}