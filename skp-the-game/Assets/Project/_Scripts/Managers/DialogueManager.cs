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
    [SerializeField] private GameObject dismissButton;
    [SerializeField] private Button followButton;
    [SerializeField] private Image characterImage;
    [SerializeField] private TextMeshProUGUI characterName;
    [SerializeField] private TextMeshProUGUI dialogueText;

    private UniqueCharacterId cachedCharacterId;
    private string cachedDialogueText;
    private Quest cachedQuest;
    private QuestInfoSO cachedQuestInfo;

    private void Start() {
        dialogueMenu.SetActive(false);
        questFinishButton.SetActive(false);
        dismissButton.SetActive(false);
    }

    private void OnEnable() {
        GameEventsManager.Instance.dialogueEvents.onInitiateDialogue += InitiateDialogue;
        GameEventsManager.Instance.followerEvents.onCanFollowChange += HandleFollowButtonsState;
        GameEventsManager.Instance.followerEvents.onFollowerRecruited += HandleFollowButtonsState;
        GameEventsManager.Instance.followerEvents.onFollowerDismissed += HandleFollowButtonsState;
    }

    private void OnDisable() {
        GameEventsManager.Instance.followerEvents.onCanFollowChange -= HandleFollowButtonsState;
        GameEventsManager.Instance.dialogueEvents.onInitiateDialogue -= InitiateDialogue;
        GameEventsManager.Instance.followerEvents.onFollowerRecruited -= HandleFollowButtonsState;
        GameEventsManager.Instance.followerEvents.onFollowerDismissed -= HandleFollowButtonsState;
    }

    public void OnFollowButtonClick() {
        GameEventsManager.Instance.followerEvents.RecruitFollower(cachedCharacterId);
    }

    public void OnDismissButtonClick() {
        GameEventsManager.Instance.followerEvents.DismissFollower(cachedCharacterId);
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
        cachedCharacterId = characterSo.characterId;
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

        HandleFollowButtonsState(cachedCharacterId);
        HandleQuestStateView();
    }

    private void HandleQuestStateView() {
        bool hasNoQuest = cachedQuestInfo == null;
        bool questCanBeFinished = !hasNoQuest && cachedQuest.state == QuestState.CanFinish;
        bool questIsFinished = !hasNoQuest && cachedQuest.state == QuestState.Finished;

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

    private void HandleFollowButtonsState(UniqueCharacterId id) {
        if (id != cachedCharacterId) {
            return;
        }

        Follower followerInfo = FollowerManager.Instance.GetFollowerInfo(cachedCharacterId);
        bool canFollow = followerInfo.canFollow;
        bool isFollowing = followerInfo.isFollowing;

        Debug.Log("Can follow: " + canFollow + " Is following: " + isFollowing);

        if (isFollowing) {
            dismissButton.SetActive(true);
            followButton.gameObject.SetActive(false);
        } else {
            followButton.gameObject.SetActive(true);
            dismissButton.SetActive(false);
            followButton.interactable = canFollow;
        }
    }
}