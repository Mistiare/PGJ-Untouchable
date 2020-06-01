using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 moveVector;
    [SerializeField]
    private float speed = 0;


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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            moveVector.y = 3;
        }

        transform.GetComponent<Rigidbody>().AddForce(moveVector * speed, ForceMode.Force);
    }
}
