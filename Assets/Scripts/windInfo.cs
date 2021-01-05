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
    private PlayerMovement playerScript;
    private bool colliding;


    void Start()
    {
        playerScript = player.GetComponent<PlayerMovement>();
    }


    void FixedUpdate()
    {
        if (colliding && player != null)
        {
            Vector3 pointX = transform.TransformPoint(direction);           
            pointX -= transform.position;

            playerScript.wind(pointX, speed);
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
