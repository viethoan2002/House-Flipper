using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemShopUI : MonoBehaviour
{
    [SerializeField] private BaseItem _curItem;
    [SerializeField] private Text _nameTxt, _typeTxt, _priceTxt;
    [SerializeField] private GameObject _lock, _price;

    [Button]
    public void Test()
    {
        AddItem(_curItem);
    }

    public void AddItem(BaseItem _item)
    {
        _curItem = _item;
        _nameTxt.text = _item._name;
        _typeTxt.text = _item.GetTypeString();

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
