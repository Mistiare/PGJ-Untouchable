using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField]
    private Transform[] wayPoints;
    private int destPoint;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(this.transform.position, transform.forward);
    }

    private void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        NextWayPoint();
    }

    private void Update()
    {
     if (!agent.pathPending && agent.remainingDistance <= 0.5f)
        {
            NextWayPoint();
        }
    }

    private void NextWayPoint()
    {
        if (wayPoints.Length == 0)
        {
            return;
        }
        agent.destination = wayPoints[destPoint].position;

        destPoint = (destPoint + 1) % wayPoints.Length;
    }
}
