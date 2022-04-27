using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DirectionController : MonoBehaviour
{
    [SerializeField] private GameObject directionholder;
    [SerializeField] private Slider directionSlider;
    [SerializeField] private Button button;

    [SerializeField] private BallController ballController;

    private int sliderDir = 1;

    private bool sliderCanRunning = false;

    void Start(){
        // ActiveDirectionHolder(true);
    }

    public void ActiveDirectionHolder(bool value){
        directionholder.SetActive(value);
        sliderCanRunning = true;
        directionSlider.value = directionSlider.maxValue / 2;
        button.interactable = true;
        
        if(value)
            ballController.ResetPosition();
    }

    void Update() {
        RunningSlider();
    }

    void RunningSlider(){
        float changeValue = 3f * Time.deltaTime;

        if(sliderCanRunning){
            if(sliderDir == 1){
                directionSlider.value += changeValue;
                if (directionSlider.value == directionSlider.maxValue)
                {
                    sliderDir = -1;
                }
            } else {
                directionSlider.value -= changeValue;
                if (directionSlider.value == directionSlider.minValue)
                {
                    sliderDir = 1;
                }
            }
            
        }
    }

    public void SetDirectionValue(){
        sliderCanRunning = false;
        
    }

    public float GetSliderValue(){
        return directionSlider.value;
    }
}
