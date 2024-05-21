using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataController", menuName = "Data/DataController")]
public class DataController : ScriptableObject
{
    [SerializeField] public List<BaseItem> items = new List<BaseItem>();

    public List<BaseItem> GetItemByType(String _type)
    {
        List<BaseItem> _newList= new List<BaseItem>();
        foreach(var _item in items)
        {
            if(_item.GetTypeString() == _type)
            {
                _newList.Add(_item);
            }
        }

        return _newList;
    }
}
