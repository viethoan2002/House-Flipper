using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScannerTool_Canvas : MonoBehaviour
{
    [SerializeField] private Text _paymentTxt;

    public void SetPaymentTxt(int _amount)
    {
        _paymentTxt.fontSize = 125;
        _paymentTxt.text = "Sell for \n" + _amount.ToString();
    }

    public void ClearPaymentTxt()
    {
        _paymentTxt.fontSize = 200;
        _paymentTxt.text = "---";
    }
}
