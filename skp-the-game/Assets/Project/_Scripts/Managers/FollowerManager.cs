using System;
using System.Collections.Generic;
using UnityEngine;

public class FollowerManager : Singleton<FollowerManager> {
    private readonly UniqueCharacterId[] customFollowerDefaults = { UniqueCharacterId.Valio };
    private readonly Dictionary<UniqueCharacterId, Follower> followers = new();
    public Transform followerTarget { get; private set; }

    private void Start() {
        InitializeFollowers();
    }

    private void OnEnable() {
        GameEventsManager.Instance.followerEvents.onCanFollowChange += SetCanFollow;
        GameEventsManager.Instance.followerEvents.onFollowerRecruited += OnFollowerRecruited;
        GameEventsManager.Instance.followerEvents.onFollowerDismissed += OnFollowerDismissed;

        PlayerCharacterUnit.OnPlayerSpawn += SetFollowerTarget;
    }

    private void OnDisable() {
        GameEventsManager.Instance.followerEvents.onCanFollowChange -= SetCanFollow;
        GameEventsManager.Instance.followerEvents.onFollowerRecruited -= OnFollowerRecruited;
        GameEventsManager.Instance.followerEvents.onFollowerDismissed -= OnFollowerDismissed;

        PlayerCharacterUnit.OnPlayerSpawn -= SetFollowerTarget;
    }

    private void InitializeFollowers() {
        foreach (UniqueCharacterId id in Enum.GetValues(typeof(UniqueCharacterId))) {
            if (Array.IndexOf(customFollowerDefaults, id) == -1) {
                followers[id] = new Follower(false, false);
            }
        }

        // Set custom follower defaults
        followers[UniqueCharacterId.Valio] = new Follower(true, false);
    }

    private void SetCanFollow(UniqueCharacterId id) {
        followers[id].canFollow = true;
    }

    private void OnFollowerRecruited(UniqueCharacterId id) {
        followers[id].isFollowing = true;
    }

    private void OnFollowerDismissed(UniqueCharacterId id) {
        followers[id].isFollowing = false;
    }

    private void SetFollowerTarget(Transform target) {
        followerTarget = target;
    }

    public Follower GetFollowerInfo(UniqueCharacterId id) {
        return followers[id];
    }
}