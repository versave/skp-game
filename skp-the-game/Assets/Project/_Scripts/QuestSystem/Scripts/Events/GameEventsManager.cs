// Note: Script execution order is changed for this class, so subscribers don't run into a null exception

public class GameEventsManager : Singleton<GameEventsManager> {
    public GoldEvents GoldEvents;

    protected override void Awake() {
        base.Awake();

        GoldEvents = new GoldEvents();
    }
}