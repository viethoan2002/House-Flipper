using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int _money;
    [SerializeField] private int _coint;
    [SerializeField] private PlayerController _playerCtrl;

    private void Awake()
    {
        LoadComponent();
    }

    private void Start()
    {
        UpdateStatUI();
    }

    private void LoadComponent()
    {
        _playerCtrl = GetComponent<PlayerController>();
    }

    public bool CheckMoney(int _amount)
    {
        if (_money >= _amount)
        {
            return true;
        }
        else
            return false;
    }

    public bool CheckCoint(int _amount)
    {
        if ((_coint >= _amount))
        {
            return true;
        }
        else
            return false;
    }

    public void RemoveMoney(int _amount)
    {
        _money -= _amount;

        UpdateStatUI();
    }

    public void RemveCoint(int _amount)
    {
        _coint -= _amount;

        UpdateStatUI();
    }

    public void AddMoney(int _amount)
    {
        _money += _amount;

        UpdateStatUI();
    }

    public void AddCoint(int _amount)
    {
        _coint += _amount;

        UpdateStatUI();
    }

    public void UpdateStatUI()
    {
        PopupController.instance._cointUI.SetCointTxt(_coint);
        PopupController.instance._cointUI.SetMoneyTxt(_money);
    }

    private void Reset()
    {
        LoadComponent();
    }
}
