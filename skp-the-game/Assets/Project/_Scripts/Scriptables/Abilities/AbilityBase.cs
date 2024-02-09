using UnityEngine;

public class AbilityBase : ScriptableObject {
    [field: SerializeField] public string abilityName { get; private set; }
    [field: SerializeField] public float durationSeconds { get; private set; }
    [field: SerializeField] public float cooldownSeconds { get; private set; }

    public virtual void Reset(GameObject gameObject) { }

    public virtual void Activate(GameObject gameObject) { }
}