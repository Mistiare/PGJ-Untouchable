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
    [SerializeField]
    private float downDistance = 0;
    [SerializeField]
    private Transform cameraPoint = null;


    void FixedUpdate()
    {
        moveVector = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            moveVector.x += cameraPoint.forward.x;
            moveVector.z += cameraPoint.forward.z;
        }

        else if (Input.GetKey(KeyCode.S))
        {
            moveVector.x -= cameraPoint.forward.x;
            moveVector.z -= cameraPoint.forward.z;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveVector.x += cameraPoint.right.x;
            moveVector.z += cameraPoint.right.z;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveVector.x -= cameraPoint.right.x;
            moveVector.z -= cameraPoint.right.z;
        }

        transform.GetComponent<Rigidbody>().AddForce(moveVector * speed, ForceMode.Force);


        Vector3 downPoint = new Vector3(transform.position.x, transform.position.y - downDistance, transform.position.z);
        Debug.DrawLine(transform.position, downPoint, Color.red);

        if (Input.GetKeyDown(KeyCode.Space) && Physics.Linecast(transform.position, downPoint))
        {
           transform.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
           //increase jump height if used
           // transform.GetComponent<Rigidbody>().velocity = new Vector3(this.GetComponent<Rigidbody>().velocity.x, jumpHeight, this.GetComponent<Rigidbody>().velocity.z);
        }
    }


    public void wind(Vector3 windDistance, float windSpeed)
    {
        transform.GetComponent<Rigidbody>().AddForce(windDistance * windSpeed, ForceMode.Force);
    }
}
