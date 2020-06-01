using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 moveVector;
    [SerializeField]
    private float speed = 0;
    [SerializeField]
    private float jumpHeight = 0;
    private bool grounded;
    private float downDistance;


    void FixedUpdate()
    {
        moveVector = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            moveVector.x = 1;
        }

        else if (Input.GetKey(KeyCode.S))
        {
            moveVector.x = -1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveVector.z = -1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveVector.z = 1;
        }       

        transform.GetComponent<Rigidbody>().AddForce(moveVector * speed, ForceMode.Force);

        
        Debug.DrawLine(transform.position, )

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            transform.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Floor"))
        {
            grounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("Floor"))
        {
            grounded = false;
        }
    }
}
