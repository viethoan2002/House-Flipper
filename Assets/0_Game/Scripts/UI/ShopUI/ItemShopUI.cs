using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemShopUI : MonoBehaviour
{
    [SerializeField] private Button _curButton;
    [SerializeField] private BaseItem _curItem;
    [SerializeField] private Text _nameTxt, _typeTxt, _priceTxt;
    [SerializeField] private GameObject _lock, _price;
    [SerializeField] private Image _icon;
    private void Awake()
    {
        _curButton = GetComponent<Button>();
        _curButton.onClick.AddListener(ActionClick);
    }

    public void ActionClick()
    {
        if (PlayerController.instance._playerStats.CheckMoney(_curItem._price))
        {
            PlayerController.instance._playerTools.AddBaseItem(_curItem);

            PopupController.instance._shopUI.HideImmediately(false, null);
        }
    }

    public void AddItem(BaseItem _item)
    {
        _curItem = _item;
        _nameTxt.text = _item._name;
        _typeTxt.text = _item.GetTypeString();
        _icon.sprite = _item._icon;
        _icon.SetNativeSize();

        if (!_curItem._isLock)
        {
            _lock.SetActive(false);
            _price.SetActive(true);

            _priceTxt.text=_curItem._price.ToString();
        }
        else
        {
            _lock.SetActive(true);
            _price.SetActive(false);

        }
    }
}
