using System.Linq;
using UnityEngine;

public class FetchVapePersonalQuestStep : SimpleFetchQuestStep {
    [SerializeField] private CollectibleItemBase vapePrefab;
    private readonly string vapeSpawnTag = GameTags.VapeSpawnPoint;

    private void Start() {
        SpawnVape();
    }

    protected override void OnItemAdded(InventoryItemType itemType, int amount) {
        if (itemType == fetchItemType) {
            FinishQuestStep();
            GameEventsManager.Instance.questEvents.FinishQuest(questId);
        }
    }

    private void SpawnVape() {
        Transform[] vapeSpawnPoints =
            GameObject.FindGameObjectsWithTag(vapeSpawnTag).Select(x => x.transform).ToArray();

        if (vapeSpawnPoints.Length > 0) {
            Transform spawnPoint = vapeSpawnPoints[Random.Range(0, vapeSpawnPoints.Length)];
            CollectibleItemBase vapeCollectible = Instantiate(vapePrefab, spawnPoint.position, Quaternion.identity);

            vapeCollectible.SetAllowCollect(true);
        }
    }
}