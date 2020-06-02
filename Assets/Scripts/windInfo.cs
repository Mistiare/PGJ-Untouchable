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


    void Update()
    {
        if (colliding)
        {
            player.GetComponent<PlayerMovement>().wind(direction, speed);
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
