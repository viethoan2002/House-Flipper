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
    public PlayerStatUIManager _playerStatUIManager;

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

    public void OpenShop()
    {
        _shopManager.gameObject.SetActive(true);
        _shopManager._ShopContent.SetActive(false);
        _shopManager._MENU.SetActive(true);
    }

    public void CloseShop()
    {
        _shopManager.gameObject.SetActive(false);
    }
}
