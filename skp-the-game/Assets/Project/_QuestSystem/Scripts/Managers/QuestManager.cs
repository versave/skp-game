using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {
    private readonly List<Quest> activeQuests = new();

    private void Start() {
        BroadcastInitialQuestState();
    }

    private void Update() {
        ListenForQuestRequirementsMet();
    }

    private void OnEnable() {
        GameEventsManager.Instance.questEvents.onPreStartQuest += PreStartQuest;
        GameEventsManager.Instance.questEvents.onStartQuest += StartQuest;
        GameEventsManager.Instance.questEvents.onAdvanceQuest += AdvanceQuest;
        GameEventsManager.Instance.questEvents.onFinishQuest += FinishQuest;
    }

    private void OnDisable() {
        GameEventsManager.Instance.questEvents.onPreStartQuest -= PreStartQuest;
        GameEventsManager.Instance.questEvents.onStartQuest -= StartQuest;
        GameEventsManager.Instance.questEvents.onAdvanceQuest -= AdvanceQuest;
        GameEventsManager.Instance.questEvents.onFinishQuest -= FinishQuest;
    }

    private void ChangeQuestState(string id, QuestState state) {
        Quest quest = GetQuestById(id);
        quest.state = state;

        UpdateActiveQuests(quest);
        GameEventsManager.Instance.questEvents.QuestStateChange(quest);
    }

    private bool CheckRequirementsMet(Quest quest) {
        // start true and prove to be false
        bool meetsRequirements = true;

        // Can check for any side requirements here (that are not prerequisites)
        // e.g. player level, inventory items, etc

        // check quest prerequisites for completion
        foreach (QuestInfoSO prerequisiteQuestInfo in quest.info.questPrerequisites) {
            if (GetQuestById(prerequisiteQuestInfo.id).state != QuestState.Finished) {
                meetsRequirements = false;
                break;
            }
        }

        return meetsRequirements;
    }

    private void ListenForQuestRequirementsMet() {
        // Maybe change this up to not be a for each in Update, but rather to be ran on event
        foreach (Quest quest in ResourceSystem.Instance.questsList) {
            if (quest.state == QuestState.RequirementsNotMet && CheckRequirementsMet(quest)) {
                ChangeQuestState(quest.info.id, QuestState.CanStart);
            }
        }
    }

    private void StartQuest(string questId) {
        Quest quest = GetQuestById(questId);

        if (quest.state == QuestState.CanStart) {
            quest.InstantiateCurrentQuestStep(transform);
        }

        ChangeQuestState(quest.info.id, QuestState.InProgress);
    }

    private void AdvanceQuest(string questId) {
        Quest quest = GetQuestById(questId);

        quest.MoveToNextStep();

        if (quest.CurrentStepExists()) {
            quest.InstantiateCurrentQuestStep(transform);
        } else {
            // no more steps, finish the quest
            ChangeQuestState(quest.info.id, QuestState.CanFinish);
        }
    }

    private void FinishQuest(string questId) {
        Quest quest = GetQuestById(questId);

        ChangeQuestState(quest.info.id, QuestState.Finished);
        ClaimRewards(quest);
    }

    private void ClaimRewards(Quest quest) {
        if (quest.info.questGiverId != UniqueCharacterId.None) {
            GameEventsManager.Instance.followerEvents.SetCanFollow(quest.info.questGiverId);
        }
    }

    private void BroadcastInitialQuestState() {
        foreach (Quest quest in ResourceSystem.Instance.questsList) {
            GameEventsManager.Instance.questEvents.QuestStateChange(quest);
        }
    }

    private Quest GetQuestById(string id) {
        return ResourceSystem.Instance.GetQuestById(id);
    }

    private void PreStartQuest(string questId) {
        Quest quest = GetQuestById(questId);

        if (quest.state == QuestState.PreStart) {
            quest.InstantiateCurrentQuestStep(transform);
        }
    }

    private void UpdateActiveQuests(Quest quest) {
        if (quest.state == QuestState.PreStart || quest.state == QuestState.CanStart) {
            return;
        }

        if (activeQuests.Contains(quest)) {
            activeQuests[activeQuests.IndexOf(quest)].state = quest.state;
        } else {
            activeQuests.Add(quest);
        }

        GameEventsManager.Instance.questEvents.ActiveQuestsChange(activeQuests);
    }
}