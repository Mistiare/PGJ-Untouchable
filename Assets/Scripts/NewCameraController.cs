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
    public float sensitivity = 1f;

    void Start()
    {
        cam = transform.GetChild(0);
    }


    void Update()
    {
        if (player != null)
        {
            transform.position = player.position;

            float newY = Input.GetAxis("Mouse X") * rotateSpeed * sensitivity;
            transform.Rotate(new Vector3(0, newY, 0));

            float newX = Input.GetAxis("Mouse Y") * raiseSpeed * sensitivity;

            if (cam.position.y < transform.position.y + maxHeight && newX > 0)
            {
                cam.position += new Vector3(0, newX, 0);
            }

            if (cam.position.y > transform.position.y + minHeight && newX < 0)
            {
                cam.position += new Vector3(0, newX, 0);
            }

            cam.LookAt(new Vector3(transform.position.x, transform.position.y + targetHeight, transform.position.z));
        }       
    }
}
