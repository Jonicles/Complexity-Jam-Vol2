using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    [SerializeField] GameObject organPrefab;
    [SerializeField] GameObject containedOrgan;
    [SerializeField] RectTransform transformUI;
    private void Update()
    {
        if (transformUI.hasChanged)
        {
            Vector3 newPos = Camera.main.ScreenToWorldPoint(transformUI.position);
            transform.position = new Vector3(newPos.x, newPos.y, 0f);
            containedOrgan.transform.position = transform.position;
            transformUI.hasChanged = false;
        }
    }
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
