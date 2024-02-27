using System;
using System.Collections.Generic;
using UnityEngine;

public class FollowerManager : Singleton<FollowerManager> {
    private readonly UniqueCharacterId[] customFollowerDefaults = { UniqueCharacterId.Valio };
    private readonly Dictionary<UniqueCharacterId, Follower> followers = new();

    private void Start() {
        InitializeFollowers();
    }

    private void OnEnable() {
        GameEventsManager.Instance.followerEvents.onCanFollowChange += SetCanFollow;
        GameEventsManager.Instance.followerEvents.onFollowerRecruited += OnFollowerRecruited;
        GameEventsManager.Instance.followerEvents.onFollowerDismissed += OnFollowerDismissed;
    }

    private void OnDisable() {
        GameEventsManager.Instance.followerEvents.onCanFollowChange -= SetCanFollow;
        GameEventsManager.Instance.followerEvents.onFollowerRecruited -= OnFollowerRecruited;
        GameEventsManager.Instance.followerEvents.onFollowerDismissed -= OnFollowerDismissed;
    }

    private void InitializeFollowers() {
        foreach (UniqueCharacterId id in Enum.GetValues(typeof(UniqueCharacterId))) {
            if (Array.IndexOf(customFollowerDefaults, id) == -1) {
                followers[id] = new Follower(false, false);
            }
        }

        // Set custom follower defaults
        followers[UniqueCharacterId.Valio] = new Follower(true, true);
    }

    public bool CanFollow(UniqueCharacterId id) {
        return followers[id].canFollow;
    }

    private void SetCanFollow(UniqueCharacterId id) {
        followers[id].canFollow = true;
    }

    private void OnFollowerRecruited(UniqueCharacterId id) {
        Debug.Log("Follower recruited: " + id);
    }

    private void OnFollowerDismissed(UniqueCharacterId id) {
        Debug.Log("Follower dismissed: " + id);
    }
}