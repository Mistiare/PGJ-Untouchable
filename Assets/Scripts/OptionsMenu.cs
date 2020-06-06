using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField]
    private Slider sensSlider = null;
    [SerializeField]
    private NewCameraController cameraPoint = null;
    [SerializeField]
    private TextMeshProUGUI sens = null;

    // Start is called before the first frame update
    void Start()
    {
        sensSlider.minValue = 0.5f;
        sensSlider.maxValue = 3f;
        sensSlider.value = PlayerPrefs.GetFloat("Sens");
        sens.SetText("Sensitivity: " + sensSlider.value);
    }

    // Update is called once per frame
    void Update()
    {
        sensSlider.value = Mathf.Round(sensSlider.value * 100) / 100;

        if (sensSlider.value != cameraPoint.sensitivity)
        {
            cameraPoint.sensitivity = sensSlider.value;
            sens.SetText("Sensitivity: " + sensSlider.value);
            PlayerPrefs.SetFloat("Sens", sensSlider.value);
        }
    }
}
