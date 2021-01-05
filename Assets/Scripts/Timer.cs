using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    private float timer = 0;
    private bool isTiming;
    [SerializeField]
    private Transform timerText = null;
    private TextMeshProUGUI timerTextText;
    [SerializeField]
    private int sceneID = 0;

    private bool transition;
    public bool startUp;
    [SerializeField]
    private float fadeSpeed = 0;
    private float fade = 0;
    [SerializeField]
    private int nextScene = 0;
    [SerializeField]
    private Image fadeScreen = null;
    
    [SerializeField]
    private Transform steve;


    void Start()
    {
        startUp = true;

        timerTextText = timerText.GetComponent<TextMeshProUGUI>();
    }


    public void StartTimer()
    {
        isTiming = true;
        transition = false;
        timerTextText.text = "--:--:--";
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
            timerTextText.text = text;
        }

        if (transition)
        {
            fade += fadeSpeed;
            print(fade);
            fadeScreen.color = new Color(0, 0, 0, fade);

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

        steve.GetComponent<Steve>().setStar();
    }
}
