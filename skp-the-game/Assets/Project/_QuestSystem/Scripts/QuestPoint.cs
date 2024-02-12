using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class QuestPoint : MonoBehaviour {
    public QuestInfoSO questInfoForPoint;
    [SerializeField] private QuestIcon questIcon;
    [SerializeField] private bool isStartPoint = true;
    [SerializeField] private bool isFinishPoint = true;

    private QuestState currentQuestState;

    private bool isPlayerInTrigger;
    private string questId;

    private void Start() {
        questId = questInfoForPoint.id;
        currentQuestState = questInfoForPoint.questStartingState;

        if (currentQuestState != QuestState.RequirementsNotMet) {
            questIcon.SetState(currentQuestState, isStartPoint, isFinishPoint);
        }
    }

    private void OnEnable() {
        GameEventsManager.Instance.questEvents.onQuestStateChange += QuestStateChange;
        GameEventsManager.Instance.inputEvents.onInteract += OnPlayerInteract;
    }

    private void OnDisable() {
        GameEventsManager.Instance.questEvents.onQuestStateChange -= QuestStateChange;
        GameEventsManager.Instance.inputEvents.onInteract -= OnPlayerInteract;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            isPlayerInTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            isPlayerInTrigger = false;
        }
    }

    private void QuestStateChange(Quest quest) {
        if (quest.info.id == questId) {
            currentQuestState = quest.state;
            questIcon.SetState(currentQuestState, isStartPoint, isFinishPoint);
        }
    }

    private void OnPlayerInteract() {
        if (!isPlayerInTrigger) {
            return;
        }

        Debug.Log("Player interacted with quest point" + questId + " with state " + currentQuestState);

        if (isStartPoint && currentQuestState == QuestState.CanStart) {
            GameEventsManager.Instance.questEvents.StartQuest(questId);
        } else if (isFinishPoint && currentQuestState == QuestState.CanFinish) {
            GameEventsManager.Instance.questEvents.FinishQuest(questId);
        }
    }
}