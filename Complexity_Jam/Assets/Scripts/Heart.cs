using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : InternalOrgan
{
    float heartBloodProd = 10;
    float heartOxygenUsage = 2;
    float heartFuelUsage = 1;

    public override void Place()
    {
        BloodEnabler = true;
        BloodProd = heartBloodProd;
        OxygenUsage = heartOxygenUsage;
        FuelUsage = heartFuelUsage;
        base.Place();
    }

    public override void Remove()
    {
        BloodEnabler = false;
        BloodProd = OxygenUsage = FuelSpace = 0;
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
