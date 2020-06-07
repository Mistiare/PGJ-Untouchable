using UnityEngine;
using UnityEngine.Audio;

public class EnemyAI : MonoBehaviour
{
    protected Rigidbody rb;
    protected Vector3 moveDir = new Vector3 (0f, 0f, 0f);

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
    protected AudioSource audioSource;
    [SerializeField]
    protected AudioMixerGroup sfxVolume;


    protected Vector3 playerDist;
    [SerializeField]
    protected float range = 0f;

    protected bool isMoving;
    private bool isGrounded;

    [SerializeField]
    protected GameObject player;

    [Header("State Shit")]
    [SerializeField]
    protected EnemyState state;
    [SerializeField]
    protected int id = 0;

    protected enum EnemyState 
    {
        patrol,
        shooting,
        exploding
    }

    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        GameEvents.current.OnEnemyTriggerEnter += ChangeState;
        currentWayPoint = 0;
        moveDir = Vector3.zero;
        audioSource = this.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (player != null)
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
                case EnemyState.exploding:
                    Exploding();
                    break;
            }

            isGrounded = Physics.Raycast(this.transform.position, Vector3.down, groundDistance, groundMask);
        }
    }

    private void FixedUpdate()
    {
        if (player != null)
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

    protected virtual void Exploding()
    {

    }

    protected virtual void ChangeState(int id)
    {

    }
}
