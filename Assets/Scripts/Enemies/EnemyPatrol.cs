using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 moveDir;

    [SerializeField]
    private Transform[] wayPoints;
    [SerializeField]
    private LayerMask groundMask;
    private int currentWayPoint;
    [SerializeField]
    private float groundDistance;


    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private float moveForce;
    [SerializeField]
    private float jumpForce;

    private bool isMoving;
    private bool isGrounded;


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
        isGrounded = Physics.Raycast(this.transform.position, Vector3.down, groundDistance);
        NextWayPoint();
    }

    private void FixedUpdate()
    {
        if (isMoving && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        rb.AddForce(moveDir * moveForce);
    }

    private void NextWayPoint()
    {
        if (Vector3.Distance(wayPoints[currentWayPoint].position, this.transform.position) > 2f)
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
            currentWayPoint = (currentWayPoint + 1) % wayPoints.Length;
        }
    }

}
