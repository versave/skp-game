using UnityEngine;

public class QuestPoint : MonoBehaviour {
    public QuestInfoSO questInfoForPoint;
    [SerializeField] private QuestIcon questIcon;
    [SerializeField] private bool isStartPoint = true;
    [SerializeField] private bool isFinishPoint = true;

    private QuestState currentQuestState;
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
        GameEventsManager.Instance.dialogueEvents.onQuestButtonClick += OnPlayerQuestStart;
        GameEventsManager.Instance.dialogueEvents.onQuestFinishButtonClick += OnPlayerFinishQuest;
    }

    private void OnDisable() {
        GameEventsManager.Instance.questEvents.onQuestStateChange -= QuestStateChange;
        GameEventsManager.Instance.dialogueEvents.onQuestButtonClick -= OnPlayerQuestStart;
        GameEventsManager.Instance.dialogueEvents.onQuestFinishButtonClick -= OnPlayerFinishQuest;
    }

    private void QuestStateChange(Quest quest) {
        if (quest.info.id == questId) {
            currentQuestState = quest.state;
            questIcon.SetState(currentQuestState, isStartPoint, isFinishPoint);
        }
    }

    private void OnPlayerQuestStart(string questId) {
        if (questId != this.questId) {
            return;
        }

        bool canStartQuest = currentQuestState == QuestState.CanStart || currentQuestState == QuestState.PreStart;

        if (isStartPoint && canStartQuest) {
            GameEventsManager.Instance.questEvents.StartQuest(questId);
        }
    }

    private void OnPlayerFinishQuest(string questId) {
        if (questId != this.questId) {
            return;
        }

        if (isFinishPoint && currentQuestState == QuestState.CanFinish) {
            GameEventsManager.Instance.questEvents.FinishQuest(questId);
        }
    }
}