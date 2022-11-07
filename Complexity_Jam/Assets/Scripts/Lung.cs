using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lung : InternalOrgan
{
    float lungOxygenProd = 3;
    float lungBloodUsage = 2;
    float lungFuelUsage = 1;
    public override void Place()
    {
        OxygenEnabler = true;
        OxygenProd = lungOxygenProd;
        BloodUsage = lungBloodUsage;
        FuelUsage = lungFuelUsage;
        base.Place();
    }

    public override void Remove()
    {
        OxygenEnabler = false;
        BloodUsage = FuelUsage = OxygenProd = 0;
        base.Remove();
    }
    public override void Activate()
    {
        IsActive = true;
        base.Activate();
    }
    public override void Deactivate()
    {
        IsActive = false;
        base.Deactivate();
    }
}
