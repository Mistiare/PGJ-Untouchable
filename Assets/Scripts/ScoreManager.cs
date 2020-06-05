using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private Transform[] scoreText = null;

    
    void Start()
    {
        PlayerPrefs.SetFloat("1", 38.12354f);
        PlayerPrefs.SetFloat("2", 645.12f);
        PlayerPrefs.SetFloat("3", 3.356f);
        PlayerPrefs.SetFloat("4", 12.3f);

        LoadScores();
    }


    public void LoadScores()
    {
        for (int i = 1; i < scoreText.Length + 1; i++)
        {
            string newText;

            if (PlayerPrefs.HasKey(i.ToString()))
            {
                float seconds = PlayerPrefs.GetFloat(i.ToString());

                TimeSpan score = TimeSpan.FromSeconds(seconds);
                print(score);
                newText = string.Format("{0:00}:{1:00}:{2:00}", score.Minutes, score.Seconds, score.Milliseconds);
                
            }

            else
            {
                newText = "--:--:--";
            }

            scoreText[i - 1].GetComponent<TMPro.TextMeshProUGUI>().text = newText;
        }
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
