using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTrigger : MonoBehaviour
{
    public enum triggerStates {Start, Finish}
    public triggerStates triggerID;

    void Start()
    {
        
    }


    public void OnTriggerEnter(Collider other)
    {
        if (triggerID == triggerStates.Start)
        {
            transform.parent.GetComponent<Timer>().StartTimer();
        }

        if (triggerID == triggerStates.Finish)
        {
            transform.parent.GetComponent<Timer>().EndTimer();
        }
    }
}
