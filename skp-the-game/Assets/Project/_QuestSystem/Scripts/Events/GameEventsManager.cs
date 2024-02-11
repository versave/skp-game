// Note: Script execution order is changed for this class, so subscribers don't run into a null exception

public class GameEventsManager : Singleton<GameEventsManager> {
    public GoldEvents goldEvents;
    public QuestEvents questEvents;

    protected override void Awake() {
        base.Awake();

        goldEvents = new GoldEvents();
        questEvents = new QuestEvents();
    }
}