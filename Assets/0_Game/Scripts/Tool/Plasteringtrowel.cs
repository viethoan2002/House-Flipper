using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plasteringtrowel : BaseTool
{
    [SerializeField] private Furnitures_Price _curFurniture;
    [SerializeField] private WallCracks _curWallCracks;

    [SerializeField] private float _fillPlaster = 0;
    [SerializeField] private bool _canFillPlaster;


    [SerializeField] private bool _havePlaster = false;

    public override void UseTool()
    {
        if (!_havePlaster)
        {
            if (_canFillPlaster)
            {
                UIController.Instance._handleUIManager._handleLoading.HandleFill(_fillPlaster, 3);
            }
        }
        else
        {
            if(_curWallCracks != null)
            {
                _curWallCracks.SetCanFill(true);
                _curWallCracks.FillWallCrack(2);
                UIController.Instance._handleUIManager._handleLoading.HandleFill(_curWallCracks.GetFillAmount(),2);
            }
        }
    }

    public override void AddInteractObject(GameObject _interactObj)
    {
        base.AddInteractObject(_interactObj);

        if (!_havePlaster)
        {
            var _furPrice = _interactObj.GetComponent<Furnitures_Price>();
            if (_furPrice == _curFurniture)
            {
                UIController.Instance._handleUIManager._handleLoading.SetCanFill(true);
                return;
            }
            else
                UIController.Instance._handleUIManager._handleLoading.SetCanFill(false);

            if (_furPrice.GetBaseItem() is ItemWallFinishes)
            {

                _curFurniture = _furPrice;

                ItemWallFinishes _item = (ItemWallFinishes)_furPrice.GetBaseItem();

                if (_item._type == WallFinishes.Plaster)
                {
                    _canFillPlaster = true;
                }
            }
        }
        else
        {
            var _wallCrack=_interactObj.GetComponent<WallCracks>();

            if (_wallCrack == _curWallCracks)
            {
                UIController.Instance._handleUIManager._handleLoading.SetCanFill(true);
                return;
            }
            else
                UIController.Instance._handleUIManager._handleLoading.SetCanFill(false);

                _curWallCracks = _wallCrack;
        }
    }

    public override void ClearObjectInteract()
    {
        base.ClearObjectInteract();
        UIController.Instance._handleUIManager._handleLoading.SetCanFill(false);

        if (!_havePlaster)
        {
            _canFillPlaster=false;
            _curFurniture=null;
            //_fillPlaster= UIController.Instance._handleUIManager._handleLoading.GetFillAmount();
        }
        else
        {
            if(_curWallCracks != null)
            {
                _curWallCracks.SetCanFill(false);
                _curWallCracks=null;
            }
        }
    }

    public override void CompeleteUse()
    {
        base.CompeleteUse();

        if (!_havePlaster)
        {
            _havePlaster=true;
        }
    }
}
