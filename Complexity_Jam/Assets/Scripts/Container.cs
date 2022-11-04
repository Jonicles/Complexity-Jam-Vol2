using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : Tile
{
    [SerializeField] GameObject containedOrgan;
    private void Awake()
    {
        OrganSetup();
        Occupied = true;
    }

    private void OrganSetup()
    {
        containedOrgan = Instantiate(containedOrgan, transform.position, Quaternion.identity);
        containedOrgan.GetComponent<DragNDrop>().SetCurrentTile(this);
    }

    public override void SetOccupiedStatus(bool status)
    {
        if (!status)
        {
            OrganSetup();
        }
    }
}
