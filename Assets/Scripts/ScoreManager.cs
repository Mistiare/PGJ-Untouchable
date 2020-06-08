using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private Transform[] scoreText = null;
    [SerializeField]
    private Transform totalText = null;
    [SerializeField]
    private GameObject[] steveStars = null;


    void Start()
    {
        LoadScores();
    }


    public void LoadScores()
    {
        float totalTime = 0;

        for (int i = 1; i < scoreText.Length + 1; i++)
        {
            string newText;

            if (PlayerPrefs.HasKey(i.ToString()))
            {
                float seconds = PlayerPrefs.GetFloat(i.ToString());
                totalTime += seconds;

                TimeSpan score = TimeSpan.FromSeconds(seconds);
                newText = string.Format("{0:00}:{1:00}:{2:00}", score.Minutes, score.Seconds, score.Milliseconds);
                
            }

            else
            {
                newText = "--:--:--";
            }

            scoreText[i - 1].GetComponent<TMPro.TextMeshProUGUI>().text = newText;


            string steveKey = "S" + i.ToString();

            if (PlayerPrefs.HasKey(steveKey) && PlayerPrefs.GetInt(steveKey) == 1)
            {
                steveStars[i - 1].SetActive(true);
            }

            else
            {
                steveStars[i - 1].SetActive(false);
            }
        }

        TimeSpan totalScore = TimeSpan.FromSeconds(totalTime);
        String totalTextText = string.Format("{0:00}:{1:00}:{2:00}", totalScore.Minutes, totalScore.Seconds, totalScore.Milliseconds);
        totalText.GetComponent<TMPro.TextMeshProUGUI>().text = totalTextText;
    }

    public void ResetScores()
    {
        for (int i = 1; i < scoreText.Length + 1; i++)
        {
            if (PlayerPrefs.HasKey(i.ToString()))
            {
                PlayerPrefs.DeleteKey(i.ToString());
            }

            scoreText[i -1].GetComponent<TMPro.TextMeshProUGUI>().text = "--:--:--";
        }

        LoadScores();
    }
}
