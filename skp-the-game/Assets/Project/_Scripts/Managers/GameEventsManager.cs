// Note: Script execution order is changed for this class, so subscribers don't run into a null exception

public class GameEventsManager : Singleton<GameEventsManager> {
    public GoldEvents goldEvents;
    public InputEvents inputEvents;
    public QuestEvents questEvents;

    protected override void Awake() {
        base.Awake();

        inputEvents = new InputEvents();
        goldEvents = new GoldEvents();
        questEvents = new QuestEvents();
    }
}