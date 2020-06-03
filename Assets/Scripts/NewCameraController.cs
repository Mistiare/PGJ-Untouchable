using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCameraController : MonoBehaviour
{
    [SerializeField]
    private Transform player = null;
    [SerializeField]
    private float rotateSpeed = 0;


    void Update()
    {
        transform.position = player.position;

        float newY = Input.GetAxis("Mouse X") * rotateSpeed;
        transform.Rotate(new Vector3(0, newY, 0));
    }
}
