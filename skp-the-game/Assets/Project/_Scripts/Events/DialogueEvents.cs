using System;

public class DialogueEvents {
    public Action onCloseButtonClick;
    public Action onFollowButtonClick;
    public Action<CharacterSO> onInitiateDialogue;
    public Action onQuestButtonClick;

    public void InitiateDialogue(CharacterSO characterSo) {
        onInitiateDialogue?.Invoke(characterSo);
    }

    public void FollowButtonClick() {
        onFollowButtonClick?.Invoke();
    }

    public void QuestButtonClick() {
        onQuestButtonClick?.Invoke();
    }

    public void CloseButtonClick() {
        onCloseButtonClick?.Invoke();
    }
}