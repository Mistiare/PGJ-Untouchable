using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 moveVector;
    [SerializeField]
    private float speed = 0;
    [SerializeField]
    private float speedAssist = 0;
    [SerializeField]
    private float jumpHeight = 0;
    [SerializeField]
    private Transform cameraPoint = null;
    [SerializeField]
    private float downDistance = 0;
    [SerializeField]
    private float slowMoSpeed = 0f;
    private int colliding;
    public bool canSlowMoRegen = true;
    public bool canSlowMo = true;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        moveVector = Vector3.zero;
        float newSpeed = speed;

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

        moveVector.Normalize();

        if (colliding != 0)
        {
            newSpeed *= speedAssist;
        }

        rb.AddForce(moveVector * newSpeed, ForceMode.Force);

        Vector3 downPosition = new Vector3(transform.position.x, transform.position.y - downDistance, transform.position.z);
        Debug.DrawLine(transform.position, downPosition, Color.red);

        if (Input.GetKey(KeyCode.Space) && colliding != 0 && Physics.Linecast(transform.position, downPosition))
        {
            rb.velocity = (new Vector3(rb.velocity.x, jumpHeight, rb.velocity.z));
        }
    }


    public void wind(Vector3 windDistance, float windSpeed)
    {
        rb.AddForce(windDistance * windSpeed, ForceMode.Force);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && canSlowMo)
        {
            Time.timeScale = slowMoSpeed;
            Time.fixedDeltaTime = 0.02f * slowMoSpeed;
            canSlowMoRegen = false;

        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Time.timeScale = 1f;
            Time.fixedDeltaTime = 0.02f * 1f;
            canSlowMoRegen = true;
        }
        if (canSlowMo == false)
        {
            Time.timeScale = 1f;
            Time.fixedDeltaTime = 0.02f * 1f;
            canSlowMoRegen = true;
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        colliding += 1;
    }

    public void OnCollisionExit(Collision other)
    {
        colliding -= 1;
    }
}
