using UnityEngine;

public abstract class QuestStep : MonoBehaviour {
    private bool isFinished;
    private string questId;

    protected void FinishQuestStep() {
        if (isFinished) {
            return;
        }

        Debug.Log("advancing quest");

        isFinished = true;
        GameEventsManager.Instance.questEvents.AdvanceQuest(questId);
        Destroy(gameObject);
    }

    public void InitializeQuestStep(string id) {
        questId = id;
    }
}