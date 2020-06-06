using UnityEngine;

public class MindlessDrone : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private float moveForce = 0f;
    private Vector3 moveDir;
    [SerializeField]
    private float jumpHeight = 0f;
    private bool isGrounded;
    [SerializeField]
    private float groundDistance = 0f;
    [SerializeField]
    private LayerMask groundMask = 0;
    [SerializeField]
    private GameObject ignoreCollider = null;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(this.transform.position, this.transform.forward);
        Gizmos.DrawRay(this.transform.position, -this.transform.up);
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        moveDir = this.transform.forward; //new Vector3 (Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
        Physics.IgnoreCollision(ignoreCollider.GetComponent<BoxCollider>(), this.GetComponent<CapsuleCollider>());
    }

    private void FixedUpdate() 
    {
        isGrounded = Physics.Raycast(this.transform.position, Vector3.down, groundDistance, groundMask);
        rb.AddForce(moveDir.normalized * moveForce);
        this.transform.rotation = Quaternion.LookRotation(moveDir);
        if (isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpHeight, rb.velocity.z);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer != LayerMask.NameToLayer("Ground"))
        {
            moveDir = Vector3.Reflect(moveDir, collision.contacts[0].normal);
            moveDir.y = 0f;
        }
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
}
