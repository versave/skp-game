using System;

public class FollowerEvents {
    public Action<UniqueCharacterId> onCanFollowChange;
    public Action<UniqueCharacterId> onDismissFollower;
    public Action<UniqueCharacterId> onFollowerDismissed;
    public Action<UniqueCharacterId> onFollowerRecruited;
    public Action<UniqueCharacterId> onRecruitFollower;

    public void SetCanFollow(UniqueCharacterId id) {
        onCanFollowChange?.Invoke(id);
    }

    public void DismissFollower(UniqueCharacterId id) {
        onDismissFollower?.Invoke(id);
    }

    public void FollowerDismissed(UniqueCharacterId id) {
        onFollowerDismissed?.Invoke(id);
    }

    public void FollowerRecruited(UniqueCharacterId id) {
        onFollowerRecruited?.Invoke(id);
    }

    public void RecruitFollower(UniqueCharacterId id) {
        onRecruitFollower?.Invoke(id);
    }
}