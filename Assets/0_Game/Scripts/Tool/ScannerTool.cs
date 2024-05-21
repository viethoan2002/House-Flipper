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
        if (_curPrice == null || !_curPrice.GetCanSell())
            return;

        UIController.Instance._handleUIManager._handleLoading.HandleFill(0, 3);
    }

    public override void AddInteractObject(GameObject _interactObj)
    {
        base.AddInteractObject(_interactObj);

        var _fur = _interactObj.GetComponent<Furnitures_Price>();
        UIController.Instance._handleUIManager._handleLoading.SetCanFill(true);

        if (_fur == _curPrice)
            return;

        UIController.Instance._handleUIManager._handleLoading.SetCanFill(false);
        _curPrice = _fur;
        _scannerCanvas.SetPaymentTxt(_curPrice.GetPrice());
    }

    public override void ClearObjectInteract()
    {
        base.ClearObjectInteract();
        UIController.Instance._handleUIManager._handleLoading.SetCanFill(false);
        _scannerCanvas.ClearPaymentTxt();

        if (_curPrice != null)
        {
            _curPrice = null;
        }
    }

    public override void CompeleteUse()
    {
        base.CompeleteUse();

        _curPrice.Sell();
        _curPrice = null;
    }
}
