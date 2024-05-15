using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScannerTool : BaseTool
{
    [SerializeField] private ScannerTool_Canvas _scannerCanvas;

    [Space(20)]
    [Header("Furnitures")]
    [SerializeField] private Furnitures _curFuritures;

    public override void UseTool()
    {
        if (_curFuritures == null || !_curFuritures.GetCanSell())
            return;

        UIController.Instance._handleUIManager._handleLoading.HandleFill(0, 3);
    }

    public override void AddInteractObject(GameObject _interactObj)
    {
        var _fur = _interactObj.GetComponent<Furnitures>();
        UIController.Instance._handleUIManager._handleLoading.SetCanFill(true);

        if (_fur == _curFuritures)
            return;

        UIController.Instance._handleUIManager._handleLoading.SetCanFill(false);
        _curFuritures = _fur;
        _scannerCanvas.SetPaymentTxt(_curFuritures.GetPrice());
    }

    public override void ClearObjectInteract()
    {
        base.ClearObjectInteract();
        UIController.Instance._handleUIManager._handleLoading.SetCanFill(false);
        _scannerCanvas.ClearPaymentTxt();

        if (_curFuritures != null)
        {
            _curFuritures = null;
        }
    }

    public override void CompeleteUse()
    {
        base.CompeleteUse();

        _curFuritures.Sell();
        _curFuritures = null;
    }
}
