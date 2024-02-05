using UnityEngine;

[CreateAssetMenu(fileName = "New Character")]
public class Character : ScriptableObject {
    [SerializeField] private UniqueCharacterId _characterId;
    [SerializeField] private string _displayName;
    [SerializeField] private Sprite _menuSprite;
    [SerializeField] private Vector3 _spawnPosition;
    [SerializeField] private RuntimeAnimatorController _animatorController;
    [SerializeField] private AbilityBase _ability;
    public UniqueCharacterId characterId => _characterId;
    public string displayName => _displayName;
    public Sprite menuSprite => _menuSprite;
    public Vector3 spawnPosition => _spawnPosition;
    public RuntimeAnimatorController animatorController => _animatorController;
    public AbilityBase ability => _ability;
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