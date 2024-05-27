using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerTool : BaseTool
{
    [SerializeField] private WallController _curWall;
    [SerializeField] private Furnitures_Price _curFurniture;
    [SerializeField] private Material _curMar;
    [SerializeField] private MeshRenderer _renderer;

    [SerializeField] private bool _havePaint;
    [SerializeField] private bool _fillRoller;
    [SerializeField] private int _curIndex;
    public override void UseTool()
    {
        base.UseTool();

        if(_curFurniture!=null)
        {
            _fillRoller = true;
            PopupController.instance._gameplayUI._handleUI._handleLoading.HandleFill(0,2);
        }
        else
        {
            if( _havePaint && _curWall != null)
            {
                _fillRoller=false;
                PopupController.instance._gameplayUI._handleUI._handleLoading.HandleFill(0, 3);
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

        var _furPrice = _interactObj.GetComponent<Furnitures_Price>();

        if (_furPrice != null)
        {
            if (_furPrice == _curFurniture)
            {
                PopupController.instance._gameplayUI._handleUI._handleLoading.SetCanFill(true);
                return;
            }
            else
                PopupController.instance._gameplayUI._handleUI._handleLoading.SetCanFill(false);


            if (_furPrice.GetBaseItem() is ItemWallFinishes)
            {
                ItemWallFinishes _item = (ItemWallFinishes)_furPrice.GetBaseItem();

                if (_item._type == WallFinishes.Paints)
                {
                    _curFurniture = _furPrice;
                    PopupController.instance._gameplayUI._handleUI._handleNotification.CloseWaring();
                    PopupController.instance._gameplayUI._handleUI._handleNotification.SetNoTi("Tap to get some paint");
                }
            }

            _curWall = null;
        }
        else
        {
            if (_curMar == null)
            {
                PopupController.instance._gameplayUI._handleUI._handleNotification.SetWaring("I need some paint");
            }
            else
            {
                PopupController.instance._gameplayUI._handleUI._handleNotification.CloseWaring();
                PopupController.instance._gameplayUI._handleUI._handleNotification.SetNoTi("Tap to start painting");
            }

            var _newWall = _interactObj.GetComponent<WallController>();
            if (_newWall == _curWall)
            {
                PopupController.instance._gameplayUI._handleUI._handleLoading.SetCanFill(true);
                return;
            }
            else
                PopupController.instance._gameplayUI._handleUI._handleLoading.SetCanFill(false);

            _curWall = _newWall;
            _curWall.EnableConvert(false);
            _curIndex = _index;
            _curFurniture = null;
            _animator.CrossFade("Idle", 0);
        }
    }

    public override void CompeleteUse()
    {
        base.CompeleteUse();

        if(_fillRoller)
        {
            ItemWallFinishes _item = (ItemWallFinishes)_curFurniture.GetBaseItem();
            _curMar = _item._material;
            _renderer.material = _item._material;
            _havePaint = true;
        }
        else
        {
            _curWall.PaintWall(_curMar, _curIndex);
        }

        _animator.CrossFade("Idle", 0);
    }

    public override void ClearObjectInteract()
    {
        base.ClearObjectInteract();

        PopupController.instance._gameplayUI._handleUI._handleNotification.CloseNoti();
        if (_curMar == null)
            PopupController.instance._gameplayUI._handleUI._handleNotification.SetWaring("I need some paint");

        PopupController.instance._gameplayUI._handleUI._handleLoading.SetCanFill(false);
        if(_curFurniture != null )
        {
            _curFurniture = null;
        }
        if(_curWall != null)
        {
            _curWall.EnableConvert(true);
            _curWall = null;
        }

        _animator.CrossFade("Idle", 0);
    }
}
