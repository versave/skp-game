using System;

public class FollowerEvents {
    public Action<UniqueCharacterId> onCanFollowChange;
    public Action<UniqueCharacterId> onFollowerDismissed;
    public Action<UniqueCharacterId> onFollowerRecruited;

    public void SetCanFollow(UniqueCharacterId id) {
        onCanFollowChange?.Invoke(id);
    }

    public void RecruitFollower(UniqueCharacterId id) {
        onFollowerRecruited?.Invoke(id);
    }

    public void DismissFollower(UniqueCharacterId id) {
        onFollowerDismissed?.Invoke(id);
    }
}