using UnityEngine;

public class FindCatsPersonalQuestStep : QuestStepBase {
    [SerializeField] private int catsToFind;
    private int catsFound;

    private void OnEnable() {
        GameEventsManager.Instance.objectEvents.onEnterObjectRange += OnObjectFound;
    }

    private void OnDisable() {
        GameEventsManager.Instance.objectEvents.onEnterObjectRange -= OnObjectFound;
    }

    private void OnObjectFound(ObjectType objectType) {
        if (objectType == ObjectType.Cat) {
            catsFound++;
        }

        if (catsFound >= catsToFind) {
            FinishQuestStep();
            GameEventsManager.Instance.questEvents.FinishQuest(questId);
        }
    }
}