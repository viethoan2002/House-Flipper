using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScannerTool : BaseTool
{
    [SerializeField] private ScannerTool_Canvas _scannerCanvas;

    [Space(20)]
    [Header("Furnitures")]
    [SerializeField] private Furnitures_Price _curPrice;

    public override void UseTool()
    {
        base.UseTool();

        if (_curPrice == null || !_curPrice.GetCanSell())
            return;

        PopupController.instance._gameplayUI._handleUI._handleLoading.HandleFill(0, 3);
    }

    public override void AddInteractObject(Vector3 _point, GameObject _interactObj, int _index, Vector3 _direction)
    {
        base.AddInteractObject(_point, _interactObj, _index, _direction);

        if (_interactObj.layer == LayerMask.NameToLayer("Door"))
        {
            _curDoor = _interactObj.GetComponent<DoorController>();
            if (_curDoor._isOpen)
                PopupController.instance._gameplayUI._handleUI._handleNotification.SetNoTi("Tap to close");
            else
                PopupController.instance._gameplayUI._handleUI._handleNotification.SetNoTi("Tap to open");
            return;
        }

        var _fur = _interactObj.GetComponent<Furnitures_Price>();
        PopupController.instance._gameplayUI._handleUI._handleLoading.SetCanFill(true);

        if(_fur != null )
        {
            PopupController.instance._gameplayUI._handleUI._handleNotification.SetNoTi("Tap to sell the item");
        }
        else
        {
            PopupController.instance._gameplayUI._handleUI._handleNotification.CloseNoti();
        }

        if (_fur == _curPrice)
            return;

        PopupController.instance._gameplayUI._handleUI._handleLoading.SetCanFill(false);
        _curPrice = _fur;
        _scannerCanvas.SetPaymentTxt(_curPrice.GetPrice());
    }

    public override void ClearObjectInteract()
    {
        base.ClearObjectInteract();
        PopupController.instance._gameplayUI._handleUI._handleNotification.CloseNoti();
        PopupController.instance._gameplayUI._handleUI._handleLoading.SetCanFill(false);
        _scannerCanvas.ClearPaymentTxt();

        if (_curPrice != null)
        {
            _curPrice = null;
        }
    }

    public override void CompeleteUse()
    {
        base.CompeleteUse();
        PlayerController.instance._playerStats.AddMoney((int)(_curPrice.GetBaseItem()._price * 0.75f));
        _curPrice.Sell();
        _curPrice = null;
    }
}
