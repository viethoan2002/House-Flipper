using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public MenuUIManager _menuUIManager;
    public SideBarManager _sideBarManager;
    public ShopContentManager _shopContentManager;

    public GameObject _MENU, _ShopContent;

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

    public void CloseShop()
    {
        gameObject.SetActive(false);
    }
}
