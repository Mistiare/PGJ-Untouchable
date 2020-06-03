using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MindlessDrone : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private float moveForce = 0f;
    [SerializeField]
    private Vector3 moveDir;
    [SerializeField]
    private float rotationSpeed = 0f;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(this.transform.position, this.transform.forward);
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        moveDir = this.transform.forward;
    }

    private void FixedUpdate() 
    {
        rb.AddForce(moveDir.normalized * moveForce);
        this.transform.rotation = Quaternion.LookRotation(moveDir);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer != LayerMask.NameToLayer("Ground"))
        {
            Debug.Log("HElp");
            //moveDir = -moveDir;
            moveDir = Vector3.Reflect(moveDir, collision.contacts[0].normal);
            Debug.Log(collision.contacts);
        }
    }
}
