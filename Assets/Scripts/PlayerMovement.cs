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
    private Transform cameraPoint = null;
    [SerializeField]
    private float slowMoSpeed = 0f;
    private bool touchingFloor;


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

        GetComponent<Rigidbody>().AddForce(moveVector * speed, ForceMode.Force);


        if (Input.GetKey(KeyCode.Space) && touchingFloor)
        {
            GetComponent<Rigidbody>().velocity = (new Vector3(GetComponent<Rigidbody>().velocity.x, jumpHeight, GetComponent<Rigidbody>().velocity.z));
        }
    }


    public void wind(Vector3 windDistance, float windSpeed)
    {
        GetComponent<Rigidbody>().AddForce(windDistance * windSpeed, ForceMode.Force);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Time.timeScale = slowMoSpeed;
            Time.fixedDeltaTime = 0.02f * slowMoSpeed;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Time.timeScale = 1f;
            Time.fixedDeltaTime = 0.02f * 1f;
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Floor"))
        {
            touchingFloor = true;
        }
    }

    public void OnCollisionExit(Collision other)
    {
        if (other.transform.CompareTag("Floor"))
        {
            touchingFloor = false;
        }
    }
}
