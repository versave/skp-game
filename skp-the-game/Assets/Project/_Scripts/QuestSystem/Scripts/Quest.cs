using UnityEngine;

public class Quest {
    private int currentStepIndex;
    public QuestInfoSO info;
    public QuestState state;

    public Quest(QuestInfoSO questInfo) {
        info = questInfo;
        state = QuestState.RequirementsNotMet;
        currentStepIndex = 0;
    }

    public void MoveToNextStep() {
        currentStepIndex++;
    }

    public void InstantiateCurrentQuestStep(Transform parentTransform) {
        GameObject questStepPrefab = GetCurrentQuestStepPrefab();

        if (questStepPrefab != null) {
            GameObject questStep = Object.Instantiate(questStepPrefab, parentTransform);
            questStep.GetComponent<QuestStep>().InitializeQuestStep(info.id);
        }
    }

    public bool CurrentStepExists() {
        return currentStepIndex < info.questStepPrefabs.Length;
    }

    private GameObject GetCurrentQuestStepPrefab() {
        GameObject questStepPrefab = null;

        if (CurrentStepExists()) {
            questStepPrefab = info.questStepPrefabs[currentStepIndex];
        } else {
            Debug.LogWarning(
                "Tried to get quest step prefab, but stepIndex was out of range indicating that there's no current step QuestId=" +
                info.id + ", stepIndex=" + currentStepIndex);
        }

        return questStepPrefab;
    }
}