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
        base.UseTool();

        if (!_havePlaster)
        {
            if (_canFillPlaster)
            {
                PopupController.instance._gameplayUI._handleUI._handleLoading.HandleFill(_fillPlaster, 3);
            }
        }
        else
        {
            if(_curWallCracks != null && _curWallCracks.GetFillAmount()<1)
            {
                _curWallCracks.SetCanFill(true);
                _curWallCracks.FillWallCrack(3);
                PopupController.instance._gameplayUI._handleUI._handleLoading.HandleFill(_curWallCracks.GetFillAmount(),3);
                _animator.CrossFade("Use", 0);
            }
        }
    }

    public override void AddInteractObject(Vector3 _point, GameObject _interactObj, int _index, Vector3 _direction)
    {
        base.AddInteractObject(_point,_interactObj,_index,_direction);

        if (_interactObj.layer == LayerMask.NameToLayer("Door"))
        {
            _curDoor = _interactObj.GetComponent<DoorController>();
            if (_curDoor._isOpen)
                PopupController.instance._gameplayUI._handleUI._handleNotification.SetNoTi("Tap to close");
            else
                PopupController.instance._gameplayUI._handleUI._handleNotification.SetNoTi("Tap to open");
            return;
        }

        if (!_havePlaster)
        {
            var _furPrice = _interactObj.GetComponent<Furnitures_Price>();

            if (_furPrice == _curFurniture)
            {
                PopupController.instance._gameplayUI._handleUI._handleLoading.SetCanFill(true);
                return;
            }
            else
                PopupController.instance._gameplayUI._handleUI._handleLoading.SetCanFill(false);

            if (_furPrice.GetBaseItem() is ItemWallFinishes)
            {

                _curFurniture = _furPrice;

                ItemWallFinishes _item = (ItemWallFinishes)_furPrice.GetBaseItem();

                if (_item._type == WallFinishes.Plaster)
                {
                    _canFillPlaster = true;
                    PopupController.instance._gameplayUI._handleUI._handleNotification.CloseWaring();
                    PopupController.instance._gameplayUI._handleUI._handleNotification.SetNoTi("Tap to get some plaster");
                }
            }
        }
        else
        {
            var _wallCrack=_interactObj.GetComponent<WallCracks>();

            if (_wallCrack == _curWallCracks)
            {
                PopupController.instance._gameplayUI._handleUI._handleLoading.SetCanFill(true);
                return;
            }
            else
                PopupController.instance._gameplayUI._handleUI._handleLoading.SetCanFill(false);

                _curWallCracks = _wallCrack;

            if(_curWallCracks.GetFillAmount() < 1)
            {
                PopupController.instance._gameplayUI._handleUI._handleNotification.CloseWaring();
                PopupController.instance._gameplayUI._handleUI._handleNotification.SetNoTi("Tap to start plastrinng");
            }
        }
    }

    public override void ClearObjectInteract()
    {
        base.ClearObjectInteract();
        PopupController.instance._gameplayUI._handleUI._handleLoading.SetCanFill(false);
        PopupController.instance._gameplayUI._handleUI._handleNotification.CloseNoti();

        if (!_havePlaster)
        {
            _canFillPlaster=false;
            _curFurniture=null;
            PopupController.instance._gameplayUI._handleUI._handleNotification.SetWaring("I need some plaster");
            //_fillPlaster= PopupController.instance._gameplayUI._handleUI._handleLoading.GetFillAmount();
        }
        else
        {
            if(_curWallCracks != null)
            {
                _animator.CrossFade("Idle", 0.25f);
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

        _animator.CrossFade("Idle", 0.25f);
    }
}
