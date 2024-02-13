using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {
    [SerializeField] private GameObject dialogueMenu;
    [SerializeField] private Image characterImage;
    [SerializeField] private TextMeshProUGUI characterName;
    [SerializeField] private TextMeshProUGUI dialogueText;

    private void Start() {
        dialogueMenu.SetActive(false);
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

    public void OnQuestButtonClick() {
        GameEventsManager.Instance.dialogueEvents.QuestButtonClick();
    }

    public void OnCloseButtonClick() {
        dialogueMenu.SetActive(false);
        GameEventsManager.Instance.dialogueEvents.CloseButtonClick();
    }

    private void InitiateDialogue(CharacterSO characterSo) {
        characterImage.sprite = characterSo.menuSprite;
        characterName.text = characterSo.displayName;
        dialogueText.text = characterSo.dialogueText;
        dialogueMenu.SetActive(true);
    }
}