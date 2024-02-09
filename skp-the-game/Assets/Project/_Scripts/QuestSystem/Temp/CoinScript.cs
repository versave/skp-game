using UnityEngine;

public class CoinScript : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            CollectCoin();
        }
    }

    private void CollectCoin() {
        GameEventsManager.Instance.GoldEvents.GoldGained(1);
        Destroy(gameObject);
    }
}