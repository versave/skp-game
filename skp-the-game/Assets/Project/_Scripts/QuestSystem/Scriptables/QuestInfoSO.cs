using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestInfoSO", menuName = "QuestSystem/QuestInfoSO", order = 1)]
public class QuestInfoSO : ScriptableObject {
    [field: SerializeField] public string id { get; private set; }

    [field: Header("General")]
    [field: SerializeField]
    public string displayName { get; private set; }

    [field: Header("Requirements")]
    [field: SerializeField]
    public QuestInfoSO[] questPrerequisites { get; private set; }

    [field: Header("Steps")]
    [field: SerializeField]
    public GameObject[] questStepPrefabs { get; private set; }

    [field: Header("Rewards")]
    [field: SerializeField]
    public int goldReward { get; private set; }

    // Matches the id to the name of the object / file
    private void OnValidate() {
        // @formatter:off
        #if UNITY_EDITOR
            id = name;
            EditorUtility.SetDirty(this);
        #endif
        // @formatter:on
    }
}