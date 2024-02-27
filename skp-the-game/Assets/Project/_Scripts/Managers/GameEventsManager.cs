// Note: Script execution order is changed for this class, so subscribers don't run into a null exception

public class GameEventsManager : Singleton<GameEventsManager> {
    public DialogueEvents dialogueEvents;
    public FollowerEvents followerEvents;
    public GoldEvents goldEvents;
    public InputEvents inputEvents;
    public InventoryEvents inventoryEvents;
    public ObjectEvents objectEvents;
    public QuestEvents questEvents;

    protected override void Awake() {
        base.Awake();

        inputEvents = new InputEvents();
        goldEvents = new GoldEvents();
        questEvents = new QuestEvents();
        inventoryEvents = new InventoryEvents();
        dialogueEvents = new DialogueEvents();
        objectEvents = new ObjectEvents();
        followerEvents = new FollowerEvents();
    }
}