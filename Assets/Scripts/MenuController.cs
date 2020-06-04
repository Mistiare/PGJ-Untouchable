using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] uis = null;


    public void Menu()
    {
        ShowUI(0);
    }

    public void Continue()
    {

    }

    public void LevelSelect()
    {
        ShowUI(1);
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
}
