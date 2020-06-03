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
    private Transform camera = null;


    void FixedUpdate()
    {
        moveVector = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            moveVector.x = camera.forward.x;
        }

        else if (Input.GetKey(KeyCode.S))
        {
            moveVector.x = -camera.forward.x;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveVector.z = -camera.forward.z;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveVector.z = camera.forward.z;
        }       

        transform.GetComponent<Rigidbody>().AddForce(moveVector * speed, ForceMode.Force);


        Vector3 downPoint = new Vector3(transform.position.x, transform.position.y - downDistance, transform.position.z);
        Debug.DrawLine(transform.position, downPoint, Color.red);

        if (Input.GetKeyDown(KeyCode.Space) && Physics.Linecast(transform.position, downPoint))
        {
            transform.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }
    }


    public void wind(Vector3 windDistance, float windSpeed)
    {
        transform.GetComponent<Rigidbody>().AddForce(windDistance * windSpeed, ForceMode.Force);
    }
}
