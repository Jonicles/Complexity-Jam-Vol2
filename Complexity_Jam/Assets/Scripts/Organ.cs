using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Organ : MonoBehaviour
{
    public bool IsActive { get; protected set; } = false;
    public bool IsPlaced { get; protected set; } = false;

    public bool OxygenEnabler { get; protected set; } = false;
    public bool BloodEnabler { get; protected set; } = false;
    public bool FuelEnabler { get; protected set; } = false;
    public bool WasteEnabler { get; protected set; } = false;
    public bool ReproductionEnabler { get; protected set; } = false;
    public bool OrganEnabler { get; protected set; } = false;


    public float BloodProd { get; protected set; } = 0;
    public float BloodUsage { get; protected set; } = 0;
    public float OxygenProd { get; protected set; } = 0;
    public float OxygenUsage { get; protected set; } = 0;
    public float FuelSpace { get; protected set; } = 0;
    public float FuelUsage { get; protected set; } = 0;
    

    public abstract void Activate();

    public abstract void Deactivate();

    public abstract void PlaceDisplay();

    public abstract void DragDisplay();
}
