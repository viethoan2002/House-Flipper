using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopContentManager : UIAnimation
{
    [SerializeField] private List<ItemShopUI> _items=new List<ItemShopUI>();
    [SerializeField] private DataController _curDataController;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            MoveToOrigin();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            MoveToTarget();
        }
    }

    public void SetContentByString(string _type)
    {
        foreach(var item in _items)
        {
            item.gameObject.SetActive(false);
        }

        for(int i = 0; i < _curDataController.GetItemByType(_type).Count; i++)
        {
            _items[i].AddItem(_curDataController.GetItemByType(_type)[i]);
            _items[i].gameObject.SetActive(true);
        }
    }

    public void SetAllItem()
    {
        foreach (var item in _items)
        {
            item.gameObject.SetActive(false);
        }

        for (int i = 0; i < _curDataController.items.Count; i++)
        {
            _items[i].AddItem(_curDataController.items[i]);
            _items[i].gameObject.SetActive(true);
        }
    }

    public void SetType(int _index)
    {
        switch (_index)
        {
            case 0:
                _curDataController = DataManager.instance._BackyardData;
                break;
            case 1:
                _curDataController = DataManager.instance._Lights;
                break;
            case 2:
                _curDataController = DataManager.instance._WallFinishesData;
                break;
            case 3:
                _curDataController = DataManager.instance._DoorData;
                break;
            case 4:
                _curDataController = DataManager.instance._FurnitureData;
                break;
            case 5:
                _curDataController = DataManager.instance._WindowsData;
                break;
            case 6:
                _curDataController = DataManager.instance._DecoData;
                break;
        }

        SetAllItem();
    }
}
