using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTrigger : MonoBehaviour
{
    [SerializeField]
    private bool isStart;
    

    public void OnTriggerEnter(Collider other)
    {
        if (isStart)
        {
            transform.parent.GetComponent<Timer>().StartTimer();
        }

        else
        {
            transform.parent.GetComponent<Timer>().EndTimer();
        }
    }
}
