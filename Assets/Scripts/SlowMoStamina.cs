using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlowMoStamina : MonoBehaviour
{
    [SerializeField]
    private float maxStamina = 0f;
    private float stamina;
    [SerializeField]
    private PlayerMovement slowMo = null;
    [SerializeField]
    private Slider slowMoSlider = null;
    [SerializeField]
    private float staminaDrain = 0f;
    [SerializeField]
    private float staminaGain = 0f;

    // Start is called before the first frame update
    void Start()
    {
        slowMoSlider.maxValue = maxStamina;
        stamina = maxStamina;
        slowMoSlider.value = stamina;
    }

    // Update is called once per frame
    void Update()
    {
        if (stamina < maxStamina && slowMo.canSlowMoRegen)
        {
            stamina += staminaGain * Time.deltaTime;
            if(stamina > maxStamina)
            {
                stamina = maxStamina;
            }
            slowMoSlider.value = stamina;
            if(stamina > 20)
            {
                slowMo.canSlowMo = true;
            }
        }
        if (!slowMo.canSlowMoRegen && stamina > 0)
        {
            stamina -= staminaDrain * Time.deltaTime;
            if(stamina < 0)
            {
                stamina = 0;
            }
            slowMoSlider.value = stamina;
            if (stamina < 10f)
            {
                slowMo.canSlowMo = false;
            }
        }

    }
}
