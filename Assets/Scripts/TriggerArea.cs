using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    [SerializeField]
    private int id;
    private void OnTriggerEnter(Collider other)
    {
        GameEvents.current.EnemyTriggerEnter(id);
    }
}
