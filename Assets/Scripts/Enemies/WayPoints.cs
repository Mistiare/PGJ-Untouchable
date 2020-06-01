using UnityEngine;

public class WayPoints : MonoBehaviour
{
    [SerializeField]
    [Range(0.1f, 1f)]
    private float radius;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(this.transform.position, radius);
    }
}

