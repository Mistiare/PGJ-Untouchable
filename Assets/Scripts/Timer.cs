using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    private float timer = 0;
    private bool isTiming;


    public void StartTimer()
    {
        isTiming = true;
    }


    void Update()
    {
        if (isTiming)
        {
            timer += Time.deltaTime;
        }
    }


    public void EndTimer()
    {
        isTiming = false;

        string sceneName = SceneManager.GetActiveScene().name;
        float currentScore = PlayerPrefs.GetFloat(sceneName);

        if (currentScore == 0 || currentScore < timer)
        {
            PlayerPrefs.SetFloat(sceneName, timer);
        }
    }
}
