using System;

public class DialogueEvents {
    public Action onCloseButtonClick;
    public Action onFollowButtonClick;
    public Action<CharacterSO> onInitiateDialogue;
    public Action<string> onQuestButtonClick;
    public Action<string> onQuestFinishButtonClick;

    public void InitiateDialogue(CharacterSO characterSo) {
        onInitiateDialogue?.Invoke(characterSo);
        GameEventsManager.Instance.inputEvents.TogglePlayerActions(false);
    }

    public void FollowButtonClick() {
        onFollowButtonClick?.Invoke();
    }

    public void QuestButtonClick(string questId) {
        onQuestButtonClick?.Invoke(questId);
    }

    public void QuestFinishButtonClick(string questId) {
        onQuestFinishButtonClick?.Invoke(questId);
    }

    public void CloseButtonClick() {
        onCloseButtonClick?.Invoke();
        GameEventsManager.Instance.inputEvents.TogglePlayerActions(true);
    }
}