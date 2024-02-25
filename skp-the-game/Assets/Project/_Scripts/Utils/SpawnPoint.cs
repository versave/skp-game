using UnityEngine;

public class SpawnPoint : MonoBehaviour {
    public float gizmoSize = 0.5f;
    public Color gizmoColor = Color.yellow;

    private void OnDrawGizmos() {
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireSphere(transform.position, gizmoSize);
    }
}