using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AIMovement : MonoBehaviour {
    [SerializeField] private Transform target;
    [SerializeField] private NavMeshAgent agent;

    public UniqueCharacterId characterId;

    private void Start() {
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update() {
        SetAgentDestination();
    }

    private void OnEnable() {
        GameEventsManager.Instance.followerEvents.onRecruitFollower += SetTarget;
        GameEventsManager.Instance.followerEvents.onDismissFollower += ResetTarget;
    }

    private void OnDisable() {
        GameEventsManager.Instance.followerEvents.onRecruitFollower -= SetTarget;
        GameEventsManager.Instance.followerEvents.onDismissFollower -= ResetTarget;
    }

    private void SetTarget(UniqueCharacterId id) {
        if (id == characterId) {
            ToggleAgent(true);
            target = FollowerManager.Instance.followerTarget;
            GameEventsManager.Instance.followerEvents.FollowerRecruited(id);
        }
    }

    private void ResetTarget(UniqueCharacterId id) {
        if (id == characterId) {
            ToggleAgent(false);
            target = null;
            GameEventsManager.Instance.followerEvents.FollowerDismissed(id);
        }
    }

    private void ToggleAgent(bool state) {
        agent.enabled = state;
    }

    private void SetAgentDestination() {
        // todo: Make more performant?
        if (target != null) {
            agent.SetDestination(target.position);
        }
    }
}