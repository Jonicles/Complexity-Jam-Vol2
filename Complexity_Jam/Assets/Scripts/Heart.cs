using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : InternalOrgan
{
    float heartBloodProd = 10;
    float heartOxygenUsage = 5;
    float heartFuelUsage = 5;
    public override void Activate()
    {
        IsActive = true;
        BloodProd = heartBloodProd;
        OxygenUsage = heartOxygenUsage;
        FuelUsage = heartFuelUsage;
    }

    public override void Deactivate()
    {
        IsActive = false;
        BloodProd = OxygenUsage = FuelUsage = 0;
    }
}
