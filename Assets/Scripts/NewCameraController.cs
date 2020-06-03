using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCameraController : MonoBehaviour
{
    [SerializeField]
    private Transform player = null;
    [SerializeField]
    private float rotateSpeed = 0;
    [SerializeField]
    private float raiseSpeed = 0;
    [SerializeField]
    private float maxHeight = 0;
    [SerializeField]
    private float minHeight = 0;
    [SerializeField]
    private float targetHeight = 0;
    private Transform cam;


    void Start()
    {
        cam = transform.GetChild(0);
    }


    void Update()
    {
        transform.position = player.position;

        float newY = Input.GetAxis("Mouse X") * rotateSpeed;
        transform.Rotate(new Vector3(0, newY, 0));

        float newX = Input.GetAxis("Mouse Y") * raiseSpeed;

        if (cam.position.y < maxHeight && newX > 0)
        {
            cam.position += new Vector3(0, newX, 0);
        }

        if (cam.position.y > minHeight && newX < 0)
        {
            cam.position += new Vector3(0, newX, 0);
        }

        cam.LookAt(new Vector3(transform.position.x, targetHeight, transform.position.z));
    }
}
