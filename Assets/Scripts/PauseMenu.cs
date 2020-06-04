using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu = null;
    [SerializeField]
    private GameObject optionsMenu = null;
    private void Start()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }

    public void Continue()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Cursor.visible = false;
    }

    public void Options()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

}
