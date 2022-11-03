using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : InternalOrgan
{
    public override void Activate()
    {
        IsActive = true;
        OrganEnabler = true;
        OxygenUsage = 5;
        FuelUsage = 2;
    }
    public override void Deactivate()
    {
        IsActive = OrganEnabler = false;
        OxygenUsage = FuelUsage = 0;
    }
}
