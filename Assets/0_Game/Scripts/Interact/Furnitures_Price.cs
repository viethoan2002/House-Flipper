using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furnitures_Price : MonoBehaviour
{
    [SerializeField] private BaseItem _curItem;
    [SerializeField] private bool _canSell;

    public BaseItem GetBaseItem()
    {
        return _curItem;
    }

    public int GetPrice()
    {
        return _curItem._price;
    }

    public void Sell()
    {
        Destroy(gameObject);
    }

    public bool GetCanSell()
    {
        return _canSell;
    }
}
