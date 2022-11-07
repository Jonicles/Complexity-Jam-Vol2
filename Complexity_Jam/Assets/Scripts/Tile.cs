using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool Occupied { get; protected set; }
    bool test;
    public virtual void SetOccupiedStatus(bool status)
    {
        if (!status)
        {
            Occupied = false;
        }
        else
        {
            Occupied = true;
        }
        
    }

    public void Show(bool show)
    {
        //Logic for tile appearing or disappearing
        gameObject.SetActive(show);
    }
}
