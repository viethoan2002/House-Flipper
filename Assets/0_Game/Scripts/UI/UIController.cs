using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController Instance;

    [Space(30)]
    [Header("UI Component")]
    public HandleUIManager _handleUIManager;
    public ToolUIManager _toolUIManager;
    public ReplaceUIManager _replaceUIManager;
    public ShopManager _shopManager;

    private void Awake()
    {
        if(UIController.Instance == null)
        {
            UIController.Instance = this;
        }
    }

    public void Test()
    {
        Debug.Log("Click");
    }

    public void TargetPaints()
    {

    }
}
