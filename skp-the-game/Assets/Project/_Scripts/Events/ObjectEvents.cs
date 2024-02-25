using System;

public class ObjectEvents {
    public Action<ObjectType> onEnterObjectRange;
    public Action<ObjectType> onExitObjectRange;

    public void EnterObjectRange(ObjectType objectType) {
        onEnterObjectRange?.Invoke(objectType);
    }

    public void ExitObjectRange(ObjectType objectType) {
        onExitObjectRange?.Invoke(objectType);
    }
}