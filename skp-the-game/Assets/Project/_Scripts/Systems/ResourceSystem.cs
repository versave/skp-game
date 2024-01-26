using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
///     One repository for all scriptable objects. Create your query methods here to keep your business logic clean.
/// </summary>
public class ResourceSystem : StaticInstance<ResourceSystem> {
    private Dictionary<UniqueCharacterId, Character> _charactersDict;
    public List<Character> characters { get; private set; }

    protected override void Awake() {
        base.Awake();
        AssembleResources();
    }

    private void AssembleResources() {
        characters = Resources.LoadAll<Character>("Characters").ToList();
        _charactersDict = characters.ToDictionary(character => character.characterId, character => character);
    }

    public Character GetCharacter(UniqueCharacterId id) {
        return _charactersDict[id];
    }
}