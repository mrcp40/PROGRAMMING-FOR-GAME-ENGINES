using UnityEngine;

public class WayPointScript : MonoBehaviour
{
    [SerializeField]
    private float _gizmoRadius = 1.0f;
    [SerializeField]
    private Color _gizmoColor = Color.red;

    private void OnDrawGizmos()
    {
        Gizmos.color = _gizmoColor;
        Gizmos.DrawSphere(transform.position, _gizmoRadius);
    }
}
