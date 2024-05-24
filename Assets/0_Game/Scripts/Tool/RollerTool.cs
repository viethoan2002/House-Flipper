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
        if(_curFurniture!=null)
        {
            _fillRoller = true;
            UIController.Instance._handleUIManager._handleLoading.HandleFill(0,2);
        }
        else
        {
            if( _havePaint && _curWall != null)
            {
                _fillRoller=false;
                UIController.Instance._handleUIManager._handleLoading.HandleFill(0, 3);
                _animator.CrossFade("Use", 0);
            }
        }
    }

    public override void AddInteractObject(GameObject _interactObj)
    {
        base.AddInteractObject(_interactObj);
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

        UIController.Instance._handleUIManager._handleNotification.CloseNoti();
        if (_curMar == null)
            UIController.Instance._handleUIManager._handleNotification.SetWaring("I need some paint");

        UIController.Instance._handleUIManager._handleLoading.SetCanFill(false);
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

    public override void AddTriangleIndex(int _index, GameObject _interactObj)
    {
        base.AddInteractObject(_interactObj);

        var _furPrice = _interactObj.GetComponent<Furnitures_Price>();

        if (_furPrice != null)
        {
            if (_furPrice == _curFurniture)
            {
                UIController.Instance._handleUIManager._handleLoading.SetCanFill(true);
                return;
            }
            else
                UIController.Instance._handleUIManager._handleLoading.SetCanFill(false);


            if (_furPrice.GetBaseItem() is ItemWallFinishes)
            {
                ItemWallFinishes _item = (ItemWallFinishes)_furPrice.GetBaseItem();

                if (_item._type == WallFinishes.Paints)
                {
                    _curFurniture = _furPrice;
                    UIController.Instance._handleUIManager._handleNotification.CloseWaring();
                    UIController.Instance._handleUIManager._handleNotification.SetNoTi("Tap to get some paint");
                }
            }

            _curWall = null;
        }
        else
        {
            if (_curMar == null)
            {
                UIController.Instance._handleUIManager._handleNotification.SetWaring("I need some paint");
            }
            else
            {
                UIController.Instance._handleUIManager._handleNotification.CloseWaring();
                UIController.Instance._handleUIManager._handleNotification.SetNoTi("Tap to start painting");
            }

            var _newWall = _interactObj.GetComponent<WallController>();
            if (_newWall == _curWall)
            {
                UIController.Instance._handleUIManager._handleLoading.SetCanFill(true);
                return;
            }
            else
                UIController.Instance._handleUIManager._handleLoading.SetCanFill(false);

            _curWall = _newWall;
            _curWall.EnableConvert(false);
            _curIndex = _index;
            _curFurniture = null;
            _animator.CrossFade("Idle", 0);
        }
   
    }
}
