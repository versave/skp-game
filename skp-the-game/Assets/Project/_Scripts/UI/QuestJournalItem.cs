using TMPro;
using UnityEngine;

public class QuestJournalItem : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI questTitleText;
    [SerializeField] private TextMeshProUGUI questDescriptionText;
    [SerializeField] private TextMeshProUGUI questSourceText;
    [SerializeField] private TextMeshProUGUI questProgressText;

    public string questId;

    public void InitUI(Quest quest) {
        questId = quest.info.id;
        UpdateUI(quest);
    }

    public void UpdateUI(Quest quest) {
        questTitleText.text = quest.info.displayName;
        questDescriptionText.text = quest.info.description;
        questSourceText.text = quest.info.questGiverName;
        questProgressText.text = quest.state.ToString();
    }
}