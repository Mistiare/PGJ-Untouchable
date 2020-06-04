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
    private Slider xSensSlider = null;
    [SerializeField]
    private Slider ySensSlider = null;
    [SerializeField]
    private NewCameraController cameraPoint = null;
    [SerializeField]
    private TextMeshProUGUI xSens = null;
    [SerializeField]
    private TextMeshProUGUI ySens = null;
    private bool paused;
    private void Start()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
        xSensSlider.minValue = 0.5f;
        xSensSlider.maxValue = 5f;
        ySensSlider.minValue = 0.01f;
        ySensSlider.maxValue = 2f;
        paused = false;
        xSensSlider.value = cameraPoint.rotateSpeed;
        ySensSlider.value = cameraPoint.raiseSpeed;
        xSens.SetText("X sensitivity: " + xSensSlider.value);
        ySens.SetText("Y sensitivity: " + ySensSlider.value);
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

        xSensSlider.value = Mathf.Round(xSensSlider.value * 100) / 100;
        ySensSlider.value = Mathf.Round(ySensSlider.value * 100) / 100;

        if(xSensSlider.value != cameraPoint.rotateSpeed)
        {
            cameraPoint.rotateSpeed = xSensSlider.value;
            xSens.SetText("X sensitivity: " + xSensSlider.value);
        }
        if(ySensSlider.value != cameraPoint.raiseSpeed)
        {
            cameraPoint.raiseSpeed = ySensSlider.value;
            ySens.SetText("Y sensitivity: " + ySensSlider.value);

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
