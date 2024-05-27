using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupShop : BasePopup
{
    public MenuUIManager _menuUIManager;
    public SideBarManager _sideBarManager;
    public ShopContentManager _shopContentManager;

    public GameObject _MENU, _ShopContent;

    [SerializeField] private Button _btnBack, _btnExit;

    private void Awake()
    {
        _btnBack.onClick.AddListener(BackToMenuShop);
        _btnExit.onClick.AddListener(HideShop);
    }

    public void BackToMenuShop()
    {
        _ShopContent.SetActive(false);
        _MENU.SetActive(true);
    }

    public void BackToShopContent()
    {
        _MENU.SetActive(false);
        _ShopContent.SetActive(true);
        _sideBarManager.MoveToTarget();
        _shopContentManager.MoveToTarget();
    }

    private void HideShop()
    {
        BackToMenuShop();
        HideImmediately(false, null);
    }

    public void CloseShop()
    {
        gameObject.SetActive(false);
    }
}
