using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour
{
    [SerializeField] Image toolTipImage;
    [SerializeField] GameObject toolTipText;
    [SerializeField] float hoverTime;
    float currentTime;
    bool isHovering;
    bool hasAppeared;

    private void Start()
    {
        toolTipImage.color = new Color(toolTipImage.color.r, toolTipImage.color.g, toolTipImage.color.g, 0);
        toolTipText.SetActive(false);
    }
    public void OnMouseEnter()
    {
        currentTime = 0;
        isHovering = true;
    }
    private void Update()
    {
        if (isHovering)
        {
            currentTime += Time.deltaTime;
            if (currentTime > hoverTime && !hasAppeared)
            {
                //time to appear
                hasAppeared = Appear();
            }
        }
    }

    private bool Appear()
    {
        toolTipImage.color = new Color(toolTipImage.color.r, toolTipImage.color.g, toolTipImage.color.g, 120);
        toolTipText.SetActive(true);
        return true;
    }

    public void OnMouseExit()
    {
        toolTipImage.color = new Color(toolTipImage.color.r, toolTipImage.color.g, toolTipImage.color.g, 0);
        toolTipText.SetActive(false);
        isHovering = false;
        hasAppeared = false;
    }
}
