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

    private bool transition;
    public bool startUp;
    [SerializeField]
    private float fadeSpeed = 0;
    [SerializeField]
    private int nextScene = 0;
    [SerializeField]
    private Image fadeScreen = null;


    void Start()
    {
        startUp = true;
    }


    public void StartTimer()
    {
        isTiming = true;
        transition = false;
        timerText.GetComponent<TMPro.TextMeshProUGUI>().text = "--:--:--";
    }


    void Update()
    {
        if (startUp)
        {
            fadeScreen.color -= new Color(0, 0, 0, fadeSpeed);

            if (fadeScreen.color.a == 0)
            {
                startUp = false;
            }
        }

        if (isTiming)
        {
            timer += Time.deltaTime;

            TimeSpan score = TimeSpan.FromSeconds(timer);
            String text = string.Format("{0:00}:{1:00}:{2:00}", score.Minutes, score.Seconds, score.Milliseconds);
            timerText.GetComponent<TMPro.TextMeshProUGUI>().text = text;
        }

        if (transition)
        {
            fadeScreen.color += new Color(0, 0, 0, fadeSpeed);

            if (fadeScreen.color.a > 1)
            {
                transition = false;
                SceneManager.LoadScene(nextScene);
            }
        }
    }


    public void EndTimer()
    {
        isTiming = false;
        transition = true;
        float currentScore = PlayerPrefs.GetFloat(sceneID.ToString());

        if (currentScore == 0 || currentScore > timer)
        {
            PlayerPrefs.SetFloat(sceneID.ToString(), timer);
        }
    }
}
