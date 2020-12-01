using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] uis = null;
    public PlayableDirector timeline;
    private bool reverse = false;

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void Menu()
    {
        ShowUI(0);
    }

    public void Reload()
    {

    }

    public void LevelSelect()
    {
        //ShowUI(1);
        timeline.Play();
    }

    public void BackLevelSelect()
    {
        timeline.Stop();
        timeline.time = timeline.playableAsset.duration - 0.01;
        timeline.Evaluate();
        reverse = true;
    }

    public void Options()
    {
        ShowUI(2);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Level(int level)
    {
        SceneManager.LoadScene(level);
    }


    private void ShowUI(int UI)
    {
        for (int i = 0; i < uis.Length; i++)
        {
            uis[i].SetActive(false);
        }

        uis[UI].SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

        if (reverse)
        {
            double t = timeline.time - Time.deltaTime;
            if (t < 0)
            {
                t = 0;
            }
            timeline.time = t;
            timeline.Evaluate();

            if (t == 0)
            {
                timeline.Stop();
                reverse = false;
            }
        }
    }
}
