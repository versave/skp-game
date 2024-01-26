using UnityEngine;

[CreateAssetMenu(fileName = "New Character")]
public class Character : ScriptableObject {
    [SerializeField] private UniqueCharacterId _characterId;
    public string displayName;
    public Sprite menuSprite;
    public Vector2 spawnPosition;
    public UniqueCharacterId characterId => _characterId;
}

public enum UniqueCharacterId {
    Stanislav,
    Bojko,
    Ivo,
    Valio,
    Vasko,
    Niki,
    Mitko,
    Sami
}