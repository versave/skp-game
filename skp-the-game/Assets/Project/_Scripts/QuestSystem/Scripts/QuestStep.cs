using UnityEngine;

public abstract class QuestStep : MonoBehaviour {
    private bool isFinished;

    protected void FinishQuestStep() {
        if (isFinished) {
            return;
        }

        isFinished = true;

        // todo: advance the quest forward now that we've finished this step

        Destroy(gameObject);
    }
}