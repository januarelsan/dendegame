using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerController : MonoBehaviour
{
    [SerializeField] private GameObject powerholder;
    [SerializeField] private Slider powerSlider;
    [SerializeField] private Image powerSliderFillImage;

    [SerializeField] private Button button;

    public Color maxHealthColor = Color.red;
    public Color minHealthColor = Color.green;

    private int sliderDir = 1;

    private bool sliderCanRunning = false;

    public void ActivePowerHolder(bool value){
        powerholder.SetActive(value);
        sliderCanRunning = true;
        powerSlider.value = 0;
        button.interactable = true;
    }

    void Update() {
        RunningSlider();
    }

    void RunningSlider(){
        float changeValue = 3f * Time.deltaTime;

        if(sliderCanRunning){
            if(sliderDir == 1){
                powerSlider.value += changeValue;
                if (powerSlider.value == powerSlider.maxValue)
                {
                    sliderDir = -1;
                }
            } else {
                powerSlider.value -= changeValue;
                if (powerSlider.value == powerSlider.minValue)
                {
                    sliderDir = 1;
                }
            }

            powerSliderFillImage.color = Color.Lerp(minHealthColor, maxHealthColor, (float)powerSlider.value / powerSlider.maxValue);
        }
    }

    public void SetPowerValue(){
        sliderCanRunning = false;        
        DendeGameController.Instance.ThrowBall();
    }

    public float GetSliderValue(){
        return powerSlider.value;
    }

    
}
