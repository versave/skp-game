using Cinemachine;
using UnityEngine;

public class Camera : MonoBehaviour {
    public CinemachineVirtualCamera virtualCamera;

    private void OnEnable() {
        PlayerController.OnPlayerSpawn += SetFollowTarget;
    }

    private void OnDisable() {
        PlayerController.OnPlayerSpawn -= SetFollowTarget;
    }

    public void SetFollowTarget(Transform targetTransform) {
        virtualCamera.Follow = targetTransform;
    }
}