using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U

public class StatBar : MonoBehaviour
{
    [SerializeField] GameObject statBar; 
    public Slider mySlider;

    private void Awake()
    {
        mySlider = statBar.GetComponent<Slider>();
    }
    public void UpdateValue(float value)
    {
        float tempValue = value;
        if(value > mySlider.highValue)
        {
            tempValue = mySlider.highValue;
        }

        if(value < mySlider.lowValue)
        {
            tempValue = mySlider.lowValue;
        }

        DisplayValue(tempValue);
    }

    void DisplayValue(float value)
    {
        mySlider.value = value;
    }
}
