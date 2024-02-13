using UnityEngine;

public class CoinScript : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag(GameTags.Player)) {
            CollectCoin();
        }
    }

    private void CollectCoin() {
        GameEventsManager.Instance.goldEvents.GoldGained(1);
        Destroy(gameObject);
    }
}