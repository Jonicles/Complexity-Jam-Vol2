using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouth : ExternalOrgan
{
    public override void Activate()
    {
        IsActive = true;
        LungEnabler = true;
        FuelEnabler = true;
        BloodUsage = 2;
        FuelUsage = 1;
    }
    public override void Deactivate()
    {
        IsActive = LungEnabler = FuelEnabler = false;
        BloodUsage = FuelUsage = 0;
    }
}
