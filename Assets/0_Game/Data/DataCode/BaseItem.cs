using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseItem : ScriptableObject
{
    public Sprite _icon;
    public float _price;
    public string _name;
    public bool _isLock;

    public virtual string GetTypeString()
    {
        return "";
    }
}
