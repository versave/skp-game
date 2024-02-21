using System;
using System.Collections.Generic;

public class QuestEvents {
    public Action<List<Quest>> onActiveQuestsChange;
    public Action<string> onAdvanceQuest;
    public Action<string> onFinishQuest;
    public Action<string> onPreStartQuest;
    public Action<Quest> onQuestStateChange;
    public Action<string> onStartQuest;

    public void PreStartQuest(string questId) {
        onPreStartQuest?.Invoke(questId);
    }

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

    public void ActiveQuestsChange(List<Quest> quests) {
        onActiveQuestsChange?.Invoke(quests);
    }
}