using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour {
    [SerializeField] private Transform target;
    [SerializeField] private NavMeshAgent agent;

    private void Start() {
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        // todo: remove
        Invoke(nameof(SetTarget), 1f);
    }

    private void Update() {
        if (target != null) {
            agent.SetDestination(target.position);
        }
    }

    private void SetTarget() {
        target = GameObject.Find("Player").transform;
    }
}