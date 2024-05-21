using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furnitures_Price : MonoBehaviour
{
    [SerializeField] private int _price;
    [SerializeField] private bool _canSell;

    public int GetPrice()
    {
        return _price;
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
