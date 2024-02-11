using UnityEngine;

/// <summary>
///     A static instance is similar to a singleton, but instead of destroying any new
///     instances, it overrides the current instance. This is handy for resetting the state
///     and saves you doing it manually
/// </summary>
public abstract class StaticInstance<T> : MonoBehaviour where T : MonoBehaviour {
    public static T Instance { get; private set; }

    protected virtual void Awake() {
        Instance = this as T;
    }

    protected virtual void OnApplicationQuit() {
        Instance = null;
        Destroy(gameObject);
    }
}

/// <summary>
///     Basic singleton. This will destroy any new
///     versions created, leaving the original instance intact
/// </summary>
public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour {
    public static T Instance { get; private set; }

    protected virtual void Awake() {
        if (Instance != null) { }

        if (Instance != null) {
            Debug.LogWarning("Duplicate singleton found: " + typeof(T));
            Destroy(gameObject);
        }

        Instance = this as T;
    }
}

/// <summary>
///     Finally we have a persistent version of the singleton. This will survive through scene
///     loads. Perfect for system classes which require stateful, persistent data. Or audio sources
///     where music plays through loading screens, etc
/// </summary>
public abstract class PersistentSingleton<T> : Singleton<T> where T : MonoBehaviour {
    protected override void Awake() {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
}

public abstract class NonMonoSingleton<T> where T : new() {
    private static T instance;

    public static T Instance {
        get {
            if (instance == null) {
                instance = new T();
            }

            return instance;
        }
    }
}