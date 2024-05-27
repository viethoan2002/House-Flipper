using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupCoint : BasePopup
{
    [SerializeField] private Text _moneyText, _cointText;

    public void SetMoneyTxt(int _amount)
    {
        _moneyText.text = _amount.ToString();
    }

    public void SetCointTxt(int _amount)
    {
        _cointText.text = _amount.ToString();
    }
}
