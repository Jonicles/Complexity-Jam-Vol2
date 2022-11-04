using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouth : ExternalOrgan
{
    float mouthBloodUsage = 2;
    float mouthFuelUsage = 1;
    public override void Place()
    {
        LungEnabler = true;
        FuelEnabler = true;
        BloodUsage = mouthBloodUsage;
        FuelUsage = mouthFuelUsage;
        base.Place();
    }

    public override void Remove()
    {
        LungEnabler = FuelEnabler = false;
        BloodUsage = FuelUsage = 0;
        base.Remove();
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
