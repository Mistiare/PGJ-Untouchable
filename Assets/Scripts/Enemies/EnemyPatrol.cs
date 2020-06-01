using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 moveDir;

    [SerializeField]
    private Transform[] wayPoints;
    private int currentWayPoint;

    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private float moveForce;

    private bool isMoving;


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(this.transform.position, transform.forward);
    }

    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        currentWayPoint = 0;
        moveDir = Vector3.zero;
    }

    private void Update()
    {
        NextWayPoint();
    }

    private void FixedUpdate()
    {
        rb.AddForce(moveDir * moveForce);
    }

    private void NextWayPoint()
    {
        if (Vector3.Distance(wayPoints[currentWayPoint].position, this.transform.position) > 1f)
        {
            Vector3 direction = wayPoints[currentWayPoint].position - this.transform.position;
            direction.y = 0f;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), rotationSpeed);
            if (direction.magnitude > .8)
            {
                moveDir = direction.normalized;
                isMoving = true;
            }
            else
            {
                isMoving = false;
            }
        }
        else
        {
            moveDir = Vector3.zero;
        }
    }

}
