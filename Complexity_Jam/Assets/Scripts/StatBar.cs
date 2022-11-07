using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatBar : MonoBehaviour
{
    [SerializeField] Slider mySlider;
    [SerializeField] TextMeshProUGUI myText;
    public void UpdateValue(float value)
    {
        float tempValue = value;
        if (value > mySlider.maxValue)
        {
            tempValue = mySlider.maxValue;
            myText.text = $"+{value}";
        }
        else if (value < mySlider.minValue)
        {
            tempValue = mySlider.minValue;
            myText.text = $"{value}";
        }
        else if(value == 0)
            myText.text = $"{value}";
        else
            myText.text = $"+{value}";

        DisplayValue(tempValue);
    }

    void DisplayValue(float value)
    {
        mySlider.value = value;
    }
}
