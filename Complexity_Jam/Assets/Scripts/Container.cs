using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    [SerializeField] GameObject organPrefab;
    [SerializeField] GameObject containedOrgan;
    private void Start()
    {
        OrganSetup();
    }

    public void OrganSetup()
    {
        containedOrgan = null;
        containedOrgan = Instantiate(organPrefab, transform.position, Quaternion.identity);
        containedOrgan.GetComponent<DragNDrop>().SetContainer(this);
    }
}
