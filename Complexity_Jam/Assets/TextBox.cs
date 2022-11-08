using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBox : MonoBehaviour
{
    //Dictionary of list where the linetype is the key, like sound script but not with sounds
    public enum LineType { BasicFunc, Brain, Lung, Mouth, BloodProd, BloodSustain, OxygenSustain, Fuel }
    
    public void Introduction()
    {

    }
    public void Appear(LineType line)
    {
        //Canvas group alpha 1
        //Access line type from dictionary and write line/line list
    }

    public void Disappear()
    {
        //Canvas group alpha 0
    }
}
