using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApproveButton : MonoBehaviour
{
    public void OnClick()
    {
        GameManager.Instance.WinLoseCheck();
    }
}
