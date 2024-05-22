using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseItem : ScriptableObject
{
    public Sprite _icon;
    public int _price;
    public string _name;
    public bool _isLock;
    public GameObject _prefObj;

    public virtual string GetTypeString()
    {
        return "";
    }
}
