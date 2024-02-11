using System.Collections.Generic;
using UnityEngine;

// todo: It's pretty much a resource system, but for quests. Maybe combine with the existing resource system?
public class QuestManager : MonoBehaviour {
    private Dictionary<string, Quest> questMap;

    private void Awake() {
        questMap = CreateQuestMap();
    }

    private void Start() {
        // Broadcast the initial state of all quests on startup
        foreach (Quest quest in questMap.Values) {
            GameEventsManager.Instance.questEvents.QuestStateChange(quest);
        }
    }

    private void Update() {
        ListenForQuestRequirementsMet();
    }

    private void OnEnable() {
        GameEventsManager.Instance.questEvents.onStartQuest += StartQuest;
        GameEventsManager.Instance.questEvents.onAdvanceQuest += AdvanceQuest;
        GameEventsManager.Instance.questEvents.onFinishQuest += FinishQuest;
    }

    private void OnDisable() {
        GameEventsManager.Instance.questEvents.onStartQuest -= StartQuest;
        GameEventsManager.Instance.questEvents.onAdvanceQuest -= AdvanceQuest;
        GameEventsManager.Instance.questEvents.onFinishQuest -= FinishQuest;
    }

    private Dictionary<string, Quest> CreateQuestMap() {
        QuestInfoSO[] allQuests = Resources.LoadAll<QuestInfoSO>("Quests");
        Dictionary<string, Quest> idToQuestMap = new();

        foreach (QuestInfoSO questInfo in allQuests) {
            if (idToQuestMap.ContainsKey(questInfo.id)) {
                Debug.LogError("Duplicate quest ID found: " + questInfo.id);
            }

            idToQuestMap.Add(questInfo.id, new Quest(questInfo));
        }

        return idToQuestMap;
    }

    private void ChangeQuestState(string id, QuestState state) {
        Quest quest = GetQuestById(id);
        quest.state = state;
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
        foreach (Quest quest in questMap.Values) {
            if (quest.state == QuestState.RequirementsNotMet && CheckRequirementsMet(quest)) {
                ChangeQuestState(quest.info.id, QuestState.CanStart);
            }
        }
    }

    private Quest GetQuestById(string id) {
        if (questMap.ContainsKey(id)) {
            return questMap[id];
        }

        Debug.LogError("Quest not found: " + id);
        return null;
    }

    private void StartQuest(string questId) {
        Quest quest = GetQuestById(questId);
        quest.InstantiateCurrentQuestStep(transform);
        ChangeQuestState(quest.info.id, QuestState.InProgress);
    }

    private void AdvanceQuest(string questId) {
        Quest quest = GetQuestById(questId);

        // move to next step
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

        ClaimRewards(quest);
        ChangeQuestState(quest.info.id, QuestState.Finished);
    }

    private void ClaimRewards(Quest quest) {
        GameEventsManager.Instance.goldEvents.RewardGold(quest.info.goldReward);
    }
}