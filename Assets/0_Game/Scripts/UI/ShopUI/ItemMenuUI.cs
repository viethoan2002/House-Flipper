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
        UIController.Instance._shopManager._sideBarManager.SetType((int)_typeMenu);
        UIController.Instance._shopManager._shopContentManager.SetType((int)_typeMenu); 
        UIController.Instance._shopManager._shopContentManager.SetType((int)_typeMenu);

        UIController.Instance._shopManager.BackToShopContent();
    }

    private void Reset()
    {
        LoadComponent();
    }
}
