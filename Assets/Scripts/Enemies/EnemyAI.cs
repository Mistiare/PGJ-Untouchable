using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    protected Rigidbody rb;
    protected Vector3 moveDir;

    [Header("Movement Shit")]
    [SerializeField]
    protected Transform[] wayPoints;
    [SerializeField]
    protected LayerMask groundMask;
    protected int currentWayPoint;
    [SerializeField]
    protected float groundDistance;
    [SerializeField]
    protected float rotationSpeed;
    [SerializeField]
    protected float moveForce;
    [SerializeField]
    protected float jumpForce;

    private bool isMoving;
    private bool isGrounded;

    [Header("Targeting Shit")]
    [SerializeField]
    protected GameObject player;
    [SerializeField]
    protected GameObject projectile;
    [SerializeField]
    protected Transform bulletSpawn;
    protected Vector3 playerDist;
    [SerializeField]
    protected float bulletSpeed;
    [SerializeField]
    protected float fireRate;
    protected float nextFire;
    [SerializeField]
    protected float errorMargin;

    [Header("State Shit")]
    [SerializeField]
    private EnemyState state;
    [SerializeField]
    private int id;

    private enum EnemyState 
    {
        patrol,
        shooting
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(this.transform.position, transform.forward);
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(player.transform.position, errorMargin);
    }

    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        GameEvents.current.OnEnemyTriggerEnter += ChangeState;
        currentWayPoint = 0;
        moveDir = Vector3.zero;
    }

    private void Update()
    {
        switch (state)
        {
            default:
            case EnemyState.patrol:
                NextWayPoint();
                break;
            case EnemyState.shooting:
                moveDir = Vector3.zero;
                isMoving = false;
                Tartgeting();
                break;
        }

        isGrounded = Physics.Raycast(this.transform.position, Vector3.down, groundDistance, groundMask);
    }

    private void FixedUpdate()
    {
        if (isMoving && isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
        if (isMoving)
        {
            rb.AddForce(moveDir * moveForce);
        }
    }

    private void NextWayPoint()
    {
        if(wayPoints.Length > 0)
        {
            if (Vector3.Distance(wayPoints[currentWayPoint].position, this.transform.position) > 2f)
            {
                Vector3 direction = wayPoints[currentWayPoint].position - this.transform.position;
                direction.y = 0f;

                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
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
        else
        {
            return;
        }
    }

    protected virtual void Tartgeting()
    {

    }

    private void ChangeState(int id)
    {
        if (id == this.id)
        {
            state = EnemyState.shooting;
        }
    }
}
