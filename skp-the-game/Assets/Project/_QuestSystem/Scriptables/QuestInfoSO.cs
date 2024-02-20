using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestInfoSO", menuName = "Quest System/Quest Info", order = 1)]
public class QuestInfoSO : ScriptableObject {
    [field: Header("General")]
    [field: SerializeField]
    public string id { get; private set; }

    [field: SerializeField] public string displayName { get; private set; }

    [field: TextArea]
    [field: SerializeField]
    public string description { get; private set; }

    [field: TextArea]
    [field: SerializeField]
    public string finishDescription { get; private set; }


    // Other quests or other data types, like booleans that need to be completed before this quest can be started
    [field: Header("Requirements")]
    [field: SerializeField]
    public QuestState questStartingState { get; private set; } = QuestState.RequirementsNotMet;

    [field: SerializeField] public QuestInfoSO[] questPrerequisites { get; private set; }

    [field: Header("Steps")]
    [field: SerializeField]
    public QuestStepBase[] questStepPrefabs { get; private set; }

    // Rewards can be added here, like gold, items, etc.

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