using UnityEngine;

public class Quest {
    private int currentStepIndex;
    public QuestInfoSO info;
    public QuestState state;

    public Quest(QuestInfoSO questInfo) {
        info = questInfo;
        state = questInfo.questStartingState;
        currentStepIndex = 0;
    }

    public void InstantiateCurrentQuestStep(Transform parentTransform) {
        QuestStepBase questStepPrefab = GetCurrentQuestStepPrefab();

        if (questStepPrefab != null) {
            QuestStepBase questStep = Object.Instantiate(questStepPrefab, parentTransform);
            questStep.InitializeQuestStep(info.id);
        }
    }

    private QuestStepBase GetCurrentQuestStepPrefab() {
        QuestStepBase questStepPrefab = null;

        if (CurrentStepExists()) {
            questStepPrefab = info.questStepPrefabs[currentStepIndex];
        } else {
            Debug.LogWarning(
                "Tried to get quest step prefab, but stepIndex was out of range indicating that there's no current step QuestId=" +
                info.id + ", stepIndex=" + currentStepIndex);
        }

        return questStepPrefab;
    }

    public bool CurrentStepExists() {
        return currentStepIndex < info.questStepPrefabs.Length;
    }

    public void MoveToNextStep() {
        currentStepIndex++;
    }
}