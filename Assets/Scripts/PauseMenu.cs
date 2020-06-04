using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu = null;
    [SerializeField]
    private GameObject optionsMenu = null;
    [SerializeField]
    private Slider sensSlider = null;
    [SerializeField]
    private NewCameraController cameraPoint = null;
    [SerializeField]
    private TextMeshProUGUI sens = null;
    private bool paused;
    private void Start()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
        sensSlider.minValue = 0.5f;
        sensSlider.maxValue = 3f;
        sensSlider.value = 1f;
        paused = false;
        sens.SetText("Sensitivity: " + sensSlider.value);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !paused)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            paused = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && paused)
        {
            pauseMenu.SetActive(false);
            optionsMenu.SetActive(false);
            Time.timeScale = 1f;
            Cursor.visible = false;
            paused = false;
        }

        sensSlider.value = Mathf.Round(sensSlider.value * 100) / 100;

        if(sensSlider.value != cameraPoint.sensitivity)
        {
            cameraPoint.sensitivity = sensSlider.value;
            sens.SetText("Sensitivity: " + sensSlider.value);
        }

    }

    public void Continue()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Cursor.visible = false;
        paused = false;
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
