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
        _MENU.SetActive(true);
        _ShopContent.SetActive(false);
    }

    public void CloseShop()
    {
        gameObject.SetActive(false);
    }
}
