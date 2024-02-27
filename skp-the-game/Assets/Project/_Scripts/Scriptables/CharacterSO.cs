using UnityEngine;

[CreateAssetMenu(fileName = "New Character")]
public class CharacterSO : ScriptableObject {
    [field: SerializeField] public UniqueCharacterId characterId { get; private set; }
    [field: SerializeField] public string displayName { get; private set; }

    [field: TextArea]
    [field: SerializeField]
    public string dialogueText { get; private set; }

    [field: SerializeField] public Sprite menuSprite { get; private set; }
    [field: SerializeField] public Vector3 spawnPosition { get; private set; }
    [field: SerializeField] public RuntimeAnimatorController animatorController { get; private set; }
    [field: SerializeField] public AbilityBaseSO ability { get; private set; }
    [field: SerializeField] public QuestInfoSO questGiverInfo { get; private set; }
    [field: SerializeField] public QuestInfoSO personalQuestInfo { get; private set; }
}

public enum UniqueCharacterId {
    Stanislav,
    Bojko,
    Ivo,
    Valio,
    Vasko,
    Niki,
    Mitko,
    Sami,
    None
}