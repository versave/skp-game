using System.Collections.Generic;
using UnityEngine;

public class QuestJournalManager : MonoBehaviour {
    [SerializeField] private GameObject questJournalPanel;
    [SerializeField] private GameObject questJournalItemsContainer;
    [SerializeField] private QuestJournalItem questJournalItemPrefab;

    private readonly List<QuestJournalItem> initializedQuests = new();
    private bool journalOpen;

    private void OnEnable() {
        GameEventsManager.Instance.inputEvents.onQuestJournalToggled += ToggleJournal;
        GameEventsManager.Instance.questEvents.onActiveQuestsChange += UpdateJournalUI;
    }

    private void OnDisable() {
        GameEventsManager.Instance.inputEvents.onQuestJournalToggled -= ToggleJournal;
        GameEventsManager.Instance.questEvents.onActiveQuestsChange -= UpdateJournalUI;
    }

    private void ToggleJournal() {
        journalOpen = !journalOpen;
        questJournalPanel.SetActive(journalOpen);
    }

    private void UpdateJournalUI(List<Quest> activeQuests) {
        foreach (Quest quest in activeQuests) {
            bool questExists = initializedQuests.Exists(questJournalItem => questJournalItem.questId == quest.info.id);

            if (!questExists) {
                QuestJournalItem questJournalItem =
                    Instantiate(questJournalItemPrefab, questJournalItemsContainer.transform);

                questJournalItem.InitUI(quest);
                initializedQuests.Add(questJournalItem);
            } else {
                QuestJournalItem questJournalItem =
                    initializedQuests.Find(questJournalItem => questJournalItem.questId == quest.info.id);

                questJournalItem.UpdateUI(quest);
            }
        }
    }
}