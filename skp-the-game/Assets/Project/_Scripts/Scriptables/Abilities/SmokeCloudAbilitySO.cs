using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Smoke Cloud")]
public class SmokeCloudAbilitySO : AbilityBaseSO {
    [SerializeField] private ParticleSystem smokeParticlePrefab;
    private ParticleSystem smokeParticleInstance;

    public override void Reset(GameObject gameObject) {
        smokeParticleInstance.Stop();
    }

    public override void Activate(GameObject gameObject) {
        if (smokeParticleInstance == null) {
            smokeParticleInstance = Instantiate(smokeParticlePrefab, gameObject.transform);
        }

        smokeParticleInstance.Play();
    }
}