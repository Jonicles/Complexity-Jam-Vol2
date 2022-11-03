using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InternalOrgan : Organ
{
    public override void PlaceDisplay()
    {
        //This is called when the organ is placed on a tile
    }

    public override void DragDisplay()
    {
        //This is called when the organ is dragged by the player
    }

    public override void Activate() { }
    public override void Deactivate() { }
}
