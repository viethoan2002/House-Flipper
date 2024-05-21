using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideBarManager : MonoBehaviour
{
    [SerializeField] private List<ItemSideUI> _itemSideUi = new List<ItemSideUI>();
    //Backyard=0,
    //Lights=1,
    //WallFinishes=2,
    //Door=3,
    //Furniture=4,
    //Windows=5,
    //Deco=6
    public void SetType(int _index)
    {
        switch (_index)
        {
            case 0:
                SwitchEnumToStringList<Backyard>();
                break;
            case 1:
                SwitchEnumToStringList<Lights>();
                break;
            case 2:
                SwitchEnumToStringList<WallFinishes>();
                break;
            case 3:
                SwitchEnumToStringList<Door>();
                break;
            case 4:
                SwitchEnumToStringList<Furniture>();
                break;
            case 5:
                SwitchEnumToStringList<Windows>();
                break;
            case 6:
                SwitchEnumToStringList<Deco>();
                break;
        }
    }

    public void SwitchEnumToStringList<T>() where T : Enum
    {
        for (int i = 0; i < _itemSideUi.Count; i++)
        {
            _itemSideUi[i].gameObject.SetActive(false);
        }

        T[] _ts = (T[])Enum.GetValues(typeof(T));

        for (int i = 0; i < _ts.Length; i++)
        {
            _itemSideUi[i].SetTyprByString(_ts[i].ToString());
            _itemSideUi[i].gameObject.SetActive(true);
        }
    }
}
