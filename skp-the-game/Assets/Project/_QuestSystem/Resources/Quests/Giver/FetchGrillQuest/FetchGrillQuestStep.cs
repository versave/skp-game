using UnityEngine;

public class FetchGrillQuestStep : SimpleFetchQuestStep {
    [SerializeField] private CollectibleItemBase grillPrefab;
    [SerializeField] private Vector3 grillSpawnPosition;

    private void Start() {
        SpawnGrill();
    }

    private void SpawnGrill() {
        CollectibleItemBase grillCollectible = Instantiate(grillPrefab, grillSpawnPosition, Quaternion.identity);
        grillCollectible.SetAllowCollect(true);
    }
}