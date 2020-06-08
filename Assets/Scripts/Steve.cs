using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steve : MonoBehaviour
{
    [SerializeField]
    private int steveID;
    private bool fallen;
    
    
    void Update()
    {
        if ((transform.eulerAngles.x > 50 && transform.eulerAngles.x < 310) || 
            (transform.eulerAngles.z > 50 && transform.eulerAngles.z < 310))
        {
            fallen = true;
        }
    }

    public void setStar()
    {
        if (fallen)
        {
            string key = "S" + steveID.ToString();
            PlayerPrefs.SetInt(key, 1);
        }       
    }
}
