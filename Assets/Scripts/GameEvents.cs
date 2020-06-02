using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{

    public static GameEvents current;
    // Start is called before the first frame update
    private void Awake()
    {
        current = this;
    }

    public event Action<int> OnEnemyTriggerEnter;
    public void EnemyTriggerEnter(int id)
    {
        if (OnEnemyTriggerEnter != null)
        {
            OnEnemyTriggerEnter(id);
        }
    }
}
