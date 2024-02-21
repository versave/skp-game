using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {
    [SerializeField] private GameObject dialogueMenu;
    [SerializeField] private GameObject defaultActions;
    [SerializeField] private GameObject questActions;
    [SerializeField] private GameObject questMenuButton;
    [SerializeField] private GameObject questStartButton;
    [SerializeField] private GameObject questFinishButton;
    [SerializeField] private Image characterImage;
    [SerializeField] private TextMeshProUGUI characterName;
    [SerializeField] private TextMeshProUGUI dialogueText;

    private string cachedDialogueText;
    private Quest cachedQuest;
    private QuestInfoSO cachedQuestInfo;

    private void Start() {
        dialogueMenu.SetActive(false);
        questFinishButton.SetActive(false);
    }

    private void OnEnable() {
        GameEventsManager.Instance.dialogueEvents.onInitiateDialogue += InitiateDialogue;
    }

    private void OnDisable() {
        GameEventsManager.Instance.dialogueEvents.onInitiateDialogue -= InitiateDialogue;
    }

    public void OnFollowButtonClick() {
        GameEventsManager.Instance.dialogueEvents.FollowButtonClick();
    }

    public void OnQuestStartButtonClick() {
        OnCloseButtonClick();
        GameEventsManager.Instance.dialogueEvents.QuestButtonClick(cachedQuestInfo.id);
    }

    public void OnQuestFinishButtonClick() {
        ResetFinishQuestView();
        GameEventsManager.Instance.dialogueEvents.QuestFinishButtonClick(cachedQuestInfo.id);
    }

    public void OnCloseButtonClick() {
        CloseDialogue();
    }

    public void OpenQuestView() {
        if (cachedQuest.state == QuestState.InProgress) {
            DisableQuestStartButton();
        }

        dialogueText.text = cachedQuestInfo.displayName + "\n" + cachedQuestInfo.description;
        defaultActions.SetActive(false);
        questActions.SetActive(true);
    }

    public void CloseQuestView() {
        dialogueText.text = cachedDialogueText;
        defaultActions.SetActive(true);
        questActions.SetActive(false);
    }

    private void InitiateDialogue(CharacterSO characterSo) {
        cachedDialogueText = characterSo.dialogueText;
        cachedQuestInfo = characterSo.questGiverInfo;

        if (cachedQuestInfo != null) {
            cachedQuest = ResourceSystem.Instance.GetQuestById(cachedQuestInfo.id);
        }

        characterImage.sprite = characterSo.menuSprite;
        characterName.text = characterSo.displayName;
        dialogueText.text = cachedDialogueText;
        questMenuButton.SetActive(characterSo.questGiverInfo != null);
        dialogueMenu.SetActive(true);

        HandleQuestStateView();
    }

    private void HandleQuestStateView() {
        bool hasNoQuest = cachedQuestInfo == null;
        bool questCanBeFinished = cachedQuest.state == QuestState.CanFinish;
        bool questIsFinished = cachedQuest.state == QuestState.Finished;

        if (hasNoQuest || questCanBeFinished || questIsFinished) {
            questMenuButton.SetActive(false);
        }

        if (questCanBeFinished) {
            ShowFinishQuestView();
        }
    }

    private void DisableQuestStartButton() {
        questStartButton.SetActive(false);
    }

    private void CloseDialogue() {
        dialogueMenu.SetActive(false);
        CloseQuestView();

        GameEventsManager.Instance.dialogueEvents.CloseButtonClick();
    }

    private void ShowFinishQuestView() {
        questFinishButton.SetActive(true);
        dialogueText.text = cachedQuestInfo.finishDescription;
    }

    private void ResetFinishQuestView() {
        questFinishButton.SetActive(false);
        dialogueText.text = cachedDialogueText;
    }
}