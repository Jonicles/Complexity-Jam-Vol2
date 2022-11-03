using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lung : InternalOrgan
{
    public override void Activate()
    {
        IsActive = true;
        OxygenEnabler = true;
        BloodUsage = 2;
        FuelUsage = 2;
    }
    public override void Deactivate()
    {
        IsActive = OxygenEnabler = false;
        BloodUsage = FuelUsage = 0;
    }
}
