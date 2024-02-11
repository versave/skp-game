using System;

public class QuestEvents {
    public Action<string> onAdvanceQuest;
    public Action<string> onFinishQuest;
    public Action<Quest> onQuestStateChange;
    public Action<string> onStartQuest;

    public void StartQuest(string questId) {
        onStartQuest?.Invoke(questId);
    }

    public void AdvanceQuest(string questId) {
        onAdvanceQuest?.Invoke(questId);
    }

    public void FinishQuest(string questId) {
        onFinishQuest?.Invoke(questId);
    }

    public void QuestStateChange(Quest quest) {
        onQuestStateChange?.Invoke(quest);
    }
}