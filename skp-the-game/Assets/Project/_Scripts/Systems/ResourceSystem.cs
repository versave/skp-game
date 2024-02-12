using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
///     One repository for all scriptable objects. Create your query methods here to keep your business logic clean.
/// </summary>
public class ResourceSystem : StaticInstance<ResourceSystem> {
    private Dictionary<UniqueCharacterId, CharacterSO> _charactersDict;
    private Dictionary<string, Quest> _questsDict;
    public List<CharacterSO> charactersList { get; private set; }
    public List<Quest> questsList { get; private set; }

    protected override void Awake() {
        base.Awake();
        LoadCharacters();
        LoadQuests();
    }

    public CharacterSO GetCharacter(UniqueCharacterId id) {
        return _charactersDict[id];
    }

    public Quest GetQuestById(string id) {
        if (_questsDict.TryGetValue(id, out Quest questById)) {
            return questById;
        }

        Debug.LogError("Quest not found: " + id);
        return null;
    }

    private void LoadCharacters() {
        charactersList = Resources.LoadAll<CharacterSO>("Characters").ToList();
        _charactersDict = charactersList.ToDictionary(character => character.characterId, character => character);
    }

    private void LoadQuests() {
        QuestInfoSO[] allQuests = Resources.LoadAll<QuestInfoSO>("Quests");
        _questsDict = new Dictionary<string, Quest>();
        questsList = new List<Quest>();

        foreach (QuestInfoSO questInfo in allQuests) {
            if (_questsDict.ContainsKey(questInfo.id)) {
                Debug.LogError("Duplicate quest ID found: " + questInfo.id);
            }

            _questsDict.Add(questInfo.id, new Quest(questInfo));
            questsList.Add(_questsDict[questInfo.id]);
        }
    }
}