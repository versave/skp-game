using UnityEngine;

public class AbilityBase : ScriptableObject {
    [SerializeField] private string _abilityName;
    [SerializeField] private float _cooldownSeconds;
    [SerializeField] private float _durationSeconds;

    public string abilityName => _abilityName;
    public float cooldownSeconds => _cooldownSeconds;
    public float durationSeconds => _durationSeconds;
    public virtual void Reset(GameObject gameObject) { }

    public virtual void Activate(GameObject gameObject) { }
}