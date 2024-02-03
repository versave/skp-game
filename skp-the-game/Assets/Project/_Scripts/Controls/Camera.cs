using Cinemachine;
using UnityEngine;

public class Camera : MonoBehaviour {
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    private void OnEnable() {
        PlayerCharacterUnit.OnPlayerSpawn += SetFollowTarget;
    }

    private void OnDisable() {
        PlayerCharacterUnit.OnPlayerSpawn -= SetFollowTarget;
    }

    private void SetFollowTarget(Transform targetTransform) {
        virtualCamera.Follow = targetTransform;
    }
}