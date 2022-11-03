using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExternalOrgan : Organ
{
    public override void Place()
    {
        //This is called when the organ is placed on a tile
        IsPlaced = true;
    }

    public override void Remove()
    {
        //This is called when the organ is dragged by the player
        IsPlaced = false;
    }

    public override void Activate() { }
    public override void Deactivate() { }
}
