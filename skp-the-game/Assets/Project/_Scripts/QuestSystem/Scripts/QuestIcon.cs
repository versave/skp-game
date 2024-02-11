using UnityEngine;

public class QuestIcon : MonoBehaviour {
    [SerializeField] private GameObject requirementsNotMetIcon;
    [SerializeField] private GameObject canStartIcon;
    [SerializeField] private GameObject inProgressIcon;
    [SerializeField] private GameObject canFinishIcon;

    public void SetState(QuestState newState, bool startPoint, bool finishPoint) {
        requirementsNotMetIcon.SetActive(false);
        canStartIcon.SetActive(false);
        inProgressIcon.SetActive(false);
        canFinishIcon.SetActive(false);

        switch (newState) {
            case QuestState.RequirementsNotMet:
                if (startPoint) {
                    requirementsNotMetIcon.SetActive(true);
                }

                break;
            case QuestState.CanStart:
                if (startPoint) {
                    canStartIcon.SetActive(true);
                }

                break;
            case QuestState.InProgress:
                if (finishPoint) {
                    inProgressIcon.SetActive(true);
                }

                break;
            case QuestState.CanFinish:
                if (finishPoint) {
                    canFinishIcon.SetActive(true);
                }

                break;
            case QuestState.Finished:
                break;
            default:
                Debug.LogError("Invalid quest state: " + newState);
                break;
        }
    }
}