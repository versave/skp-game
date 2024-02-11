using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CircleCollider2D))]
public class QuestPoint : MonoBehaviour {
    [Header("Quest")] [SerializeField] private QuestInfoSO questInfoForPoint;

    [Header("Config")] [SerializeField] private bool startPoint = true;
    [SerializeField] private bool finishPoint = true;

    private QuestState currentQuestState;

    private InputAction interact;

    private bool isPlayerInTrigger;
    private PlayerInputActions playerControls;
    private QuestIcon questIcon;
    private string questId;

    private void Awake() {
        questId = questInfoForPoint.id;

        // todo: create an InputEvents class to handle all input events
        playerControls = new PlayerInputActions();
        interact = playerControls.Player.Interact;

        questIcon = GetComponentInChildren<QuestIcon>();
    }

    private void OnEnable() {
        GameEventsManager.Instance.questEvents.onQuestStateChange += QuestStateChange;
        interact.Enable();
        // todo: create an InputEvents class to handle all input events
        interact.performed += OnPlayerInteract;
    }

    private void OnDisable() {
        GameEventsManager.Instance.questEvents.onQuestStateChange -= QuestStateChange;
        interact.Enable();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            isPlayerInTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            isPlayerInTrigger = false;
        }
    }

    private void QuestStateChange(Quest quest) {
        if (quest.info.id == questId) {
            currentQuestState = quest.state;
            questIcon.SetState(currentQuestState, startPoint, finishPoint);
        }
    }

    private void OnPlayerInteract(InputAction.CallbackContext context) {
        if (!isPlayerInTrigger) {
            return;
        }

        if (startPoint && currentQuestState == QuestState.CanStart) {
            GameEventsManager.Instance.questEvents.StartQuest(questId);
        } else if (finishPoint && currentQuestState == QuestState.CanFinish) {
            GameEventsManager.Instance.questEvents.FinishQuest(questId);
        }
    }
}