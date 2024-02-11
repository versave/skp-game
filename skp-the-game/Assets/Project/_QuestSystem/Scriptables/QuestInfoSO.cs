using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestInfoSO", menuName = "QuestSystem/QuestInfoSO", order = 1)]
public class QuestInfoSO : ScriptableObject {
    [field: Header("General")]
    [field: SerializeField]
    public string id { get; private set; }

    [field: SerializeField] public string displayName { get; private set; }

    // Other quests or other data types, like booleans that need to be completed before this quest can be started
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