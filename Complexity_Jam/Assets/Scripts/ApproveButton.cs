using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApproveButton : MonoBehaviour
{
    [SerializeField] Image myImage;
    [SerializeField] Sprite normalSprite;
    [SerializeField] Sprite hoverSprite;

    public void OnClick()
    {
        GameManager.Instance.WinLoseCheck();
    }

    public void OnEnter()
    {
        myImage.sprite = hoverSprite;
    }

    public void OnExit()
    {
        myImage.sprite = normalSprite;
    }
}
