using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float timer = 0;
    private bool isTiming;
    [SerializeField]
    private Transform timerText = null;
    [SerializeField]
    private int sceneID = 0;


    public void StartTimer()
    {
        isTiming = true;
        timerText.GetComponent<TMPro.TextMeshProUGUI>().text = "--:--:--";
    }


    void Update()
    {
        if (isTiming)
        {
            timer += Time.deltaTime;

            TimeSpan score = TimeSpan.FromSeconds(timer);
            String text = string.Format("{0:00}:{1:00}:{2:00}", score.Minutes, score.Seconds, score.Milliseconds);
            timerText.GetComponent<TMPro.TextMeshProUGUI>().text = text;
        }
    }


    public void EndTimer()
    {
        isTiming = false;
        float currentScore = PlayerPrefs.GetFloat(sceneID.ToString());

        if (currentScore == 0 || currentScore < timer)
        {
            PlayerPrefs.SetFloat(sceneID.ToString(), timer);
        }
    }
}
