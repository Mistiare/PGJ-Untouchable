using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform player = null;
    [SerializeField]
    private float cameraDist = 0;
    [SerializeField]
    private float cushion = 0;
    [SerializeField]
    private float camSpeed = 0;
    [SerializeField]
    private float rotateSpeed = 0;
    [SerializeField]
    private float height = 0;


    void Start()
    {
        
    }


    void FixedUpdate()
    {
        if (Vector3.Distance(player.position, transform.position) < cameraDist - cushion)
        {
            transform.position -= new Vector3(transform.forward.x, 0, transform.forward.z) * camSpeed;
        }

        else if (Vector3.Distance(player.position, transform.position) > cameraDist + cushion)
        {
            transform.position += new Vector3(transform.forward.x, 0, transform.forward.z) * camSpeed;
        }


        if (transform.position.y < height - cushion)
        {
            transform.position += Vector3.up * camSpeed;
        }

        else if (transform.position.y > height + cushion)
        {
            transform.position -= Vector3.up * camSpeed;
        }

        transform.position += transform.right * Input.GetAxis("Mouse X") * rotateSpeed;

        transform.LookAt(player.position);
    }
}
