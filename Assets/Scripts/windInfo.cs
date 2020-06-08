using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windInfo : MonoBehaviour
{
    [SerializeField]
    private Vector3 direction = Vector3.zero;
    [SerializeField]
    private float speed = 0;
    [SerializeField]
    private Transform player = null;
    private bool colliding;


    void FixedUpdate()
    {
        if (colliding && player != null)
        {
            Vector3 pointX = transform.TransformPoint(direction);           
            pointX -= transform.position;

            player.GetComponent<PlayerMovement>().wind(pointX, speed);
        }
    }

    void OnTriggerEnter()
    {
        colliding = true;
    }

    void OnTriggerExit()
    {
        colliding = false;
    }
}
