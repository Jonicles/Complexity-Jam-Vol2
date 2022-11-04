using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool Occupied { get; private set; }
    public void SetOccupiedStatus(bool status)
    {
        if (!status)
        {
            Occupied = false;
            print("Not Occupied");
        }
        else
        {
            Occupied = true;
            print("Its occupied");
        }
        
    }

    public void Show(bool show)
    {
        //Logic for tile appearing or disappearing
        gameObject.SetActive(show);
    }
}
