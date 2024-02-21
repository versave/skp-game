using UnityEngine;

public abstract class QuestStepBase : MonoBehaviour {
    private bool isFinished;
    protected string questId;

    protected void FinishQuestStep() {
        if (isFinished) {
            return;
        }

        isFinished = true;
        GameEventsManager.Instance.questEvents.AdvanceQuest(questId);
        Destroy(gameObject);
    }

    public void InitializeQuestStep(string id) {
        questId = id;
    }
}