using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class QuestPoint : MonoBehaviour {
    [Header("Quest")] [SerializeField] private QuestInfoSO questInfoForPoint;

    [Header("Config")] [SerializeField] private bool startPoint = true;
    [SerializeField] private bool finishPoint = true;

    private QuestState currentQuestState;


    private bool isPlayerInTrigger;
    private QuestIcon questIcon;
    private string questId;

    private void Awake() {
        questId = questInfoForPoint.id;
        questIcon = GetComponentInChildren<QuestIcon>();
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
            questIcon.SetState(currentQuestState, startPoint, finishPoint);
        }
    }

    private void OnPlayerInteract() {
        if (!isPlayerInTrigger) {
            return;
        }

        if (startPoint && currentQuestState == QuestState.CanStart) {
            GameEventsManager.Instance.questEvents.StartQuest(questId);
        } else if (finishPoint && currentQuestState == QuestState.CanFinish) {
            GameEventsManager.Instance.questEvents.FinishQuest(questId);
        }
    }
}