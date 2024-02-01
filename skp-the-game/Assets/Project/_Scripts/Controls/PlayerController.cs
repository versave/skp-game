using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {
    public static Action<Transform> OnPlayerSpawn;

    [SerializeField] private float moveSpeed = 5f;
    private Animator animator;
    private Vector2 lastMoveDirection;
    private Vector2 moveDirection;

    private InputAction moveInputAction;
    private PlayerInputActions playerControls;
    private Rigidbody2D rigidBody;

    private void Awake() {
        playerControls = new PlayerInputActions();
    }

    private void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        OnPlayerSpawn?.Invoke(transform);
    }

    private void Update() {
        ProcessInputs();
        Animate();
    }

    private void FixedUpdate() {
        rigidBody.MovePosition(rigidBody.position + moveDirection * (moveSpeed * Time.fixedDeltaTime));
    }

    private void OnEnable() {
        moveInputAction = playerControls.Player.Move;
        moveInputAction.Enable();
    }

    private void OnDisable() {
        moveInputAction.Disable();
    }

    private void ProcessInputs() {
        if (moveDirection.x != 0) {
            lastMoveDirection = moveDirection;
        }

        moveDirection = moveInputAction.ReadValue<Vector2>();
    }

    private void Animate() {
        animator.SetFloat(PlayerAnimatorParams.AnimMoveX.ToString(), moveDirection.x);
        animator.SetFloat(PlayerAnimatorParams.AnimLastMoveX.ToString(), lastMoveDirection.x);
        animator.SetFloat(PlayerAnimatorParams.AnimMoveMagnitude.ToString(), moveDirection.sqrMagnitude);
    }
}