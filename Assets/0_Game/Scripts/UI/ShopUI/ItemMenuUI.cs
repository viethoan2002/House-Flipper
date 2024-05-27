using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemMenuUI : MonoBehaviour
{
    [SerializeField] private Button _curButton;
    [SerializeField] private Text _nameTxt;
    [SerializeField] private Menu_Type _typeMenu;
    [SerializeField] private PopupShop _shopUI;

    private void Awake()
    {
        LoadComponent();
        _curButton.onClick.AddListener(ActionClick);
    }

    private void LoadComponent()
    {
        _curButton = GetComponent<Button>();
        _nameTxt.text = _typeMenu.ToString();
    }

    public void ActionClick()
    {
        _shopUI._sideBarManager.SetType((int)_typeMenu);
        _shopUI._shopContentManager.SetType((int)_typeMenu);

        _shopUI.BackToShopContent();
    }

    private void Reset()
    {
        LoadComponent();
    }
}
