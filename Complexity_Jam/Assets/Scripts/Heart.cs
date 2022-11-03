using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : InternalOrgan
{
    float heartBloodProd = 10;
    float heartOxygenUsage = 5;
    float heartFuelUsage = 5;
    private void Awake()
    {
        BloodEnabler = true;
        BloodProd = heartBloodProd;
        OxygenUsage = heartOxygenUsage;
        FuelUsage = heartFuelUsage;
    }
    public override void Activate()
    {
        IsActive = true;
    }

    public override void Deactivate()
    {
        IsActive = false;
    }
}
