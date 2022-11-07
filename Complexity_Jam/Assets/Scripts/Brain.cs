using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : InternalOrgan
{
    float brainBloodUsage = 2;
    float brainFuelUsage = 1;
    public override void Place()
    {
        OrganEnabler = true;
        BloodUsage = brainBloodUsage;
        FuelUsage = brainFuelUsage;
        base.Place();
    }

    public override void Remove()
    {
        OrganEnabler = false;
        BloodUsage = FuelUsage = 0;
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
