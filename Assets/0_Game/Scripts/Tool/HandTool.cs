using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HandTool : BaseTool
{
    [SerializeField] private Furnitures_Place _curPlace;
    [SerializeField] private Vector3 _curPoint;

    [SerializeField] private bool _isReplace;
    [SerializeField] private bool _fixObject;

    #region Add Event Action
    public override void AddEventAction()
    {
        base.AddEventAction();

        RotateLeftBtn._startRotateLeft += RotateLeft;
        RotateRightBtn._startRotateRight += RotateRight;

        RotateLeftBtn._endRotateLeft += EndRotate;
        RotateRightBtn._endRotateRight += EndRotate;

        RevertBtn._revertReplace += Revert;
    }

    public override void RemoveEventAction()
    {
        base.RemoveEventAction();

        RotateLeftBtn._startRotateLeft -= RotateLeft;
        RotateRightBtn._startRotateRight -= RotateRight;

        RotateLeftBtn._endRotateLeft -= EndRotate;
        RotateRightBtn._endRotateRight -= EndRotate;

        RevertBtn._revertReplace -= Revert;
    }

    #endregion

    #region Base Tool
    public override void UseTool()
    {
        base.UseTool();

        if (_isReplace)
        {
            if (_curPlace.CanPlace())
            {
                _curPlace.EnableCollision(false);
                _curPlace.SetMaterialOrigin();
                PlayerController.instance._playerInteract.SetLayerTarget(GetLayerTarget());
                if (!_curPlace.IsOldFur())
                {
                    _curPlace.SetIsOldFur(true);
                    PlayerController.instance._playerTools.ChangeOldTool();
                }

                ClearObjectRepalce();
            }
        }
        else
        {
            if (_curPlace == null)
                return;

            PopupController.instance._gameplayUI._handleUI._handleLoading.HandleFill(0, 3);
        }
    }

    public override void AddInteractObject(Vector3 _point, GameObject _interactObj, int _index, Vector3 _direction)
    {
        base.AddInteractObject(_point,_interactObj, _index,_direction);

        if (_interactObj.layer == LayerMask.NameToLayer("Door"))
        {
            _curDoor = _interactObj.GetComponent<DoorController>();
            if(_curDoor._isOpen)
                PopupController.instance._gameplayUI._handleUI._handleNotification.SetNoTi("Tap to close");
            else
                PopupController.instance._gameplayUI._handleUI._handleNotification.SetNoTi("Tap to open");
            return;
        }

        if (_isReplace)
        {
            PopupController.instance._gameplayUI._handleUI._handleNotification.SetNoTi("Tap to place the item");
            goto PlaceObj;
        }

        var _place = _interactObj.GetComponent<Furnitures_Place>();
        PopupController.instance._gameplayUI._handleUI._handleLoading.SetCanFill(true);

        if(_place != null)
            PopupController.instance._gameplayUI._handleUI._handleNotification.SetNoTi("Tap to start moving the item");
        else
            PopupController.instance._gameplayUI._handleUI._handleNotification.CloseNoti();

        if (_place == _curPlace)
            return;

        PopupController.instance._gameplayUI._handleUI._handleLoading.SetCanFill(false);
        _curPlace = _place;
PlaceObj:
        if (!_isReplace)
            return;

        _curPoint = _point;

        if (_curPlace != null)
        {
            _curPlace.Replace(_curPoint, _interactObj,_direction);
        }
    }

    public override void ClearObjectInteract()
    {
        base.ClearObjectInteract();

        if (_fixObject || _isReplace)
            return;

        _curPlace = null;
    }

    public void ClearObjectRepalce()
    {
        base.ClearObjectInteract();

        PopupController.instance._gameplayUI._replaceUI.HideUI();
        PopupController.instance._gameplayUI._toolUI.ShowUI();

        _isReplace = false;
        _curPlace = null;
        _curPoint = Vector3.zero;
        _fixObject = false;

        //PlayerController.instance._playerInteract.SetLayerTarget(GetLayerTarget());
    }

    public override void CompeleteUse()
    {
        base.CompeleteUse();

        _isReplace = true;
        _curPlace.SetOrigin();
        _curPlace.SetMaterialGreen();
        _curPlace.EnableCollision(true);

        PopupController.instance._gameplayUI._toolUI.HideUI();
        PopupController.instance._gameplayUI._replaceUI.ShowUI();

        PlayerController.instance._playerInteract.SetLayerTarget(_curPlace.GetLayerReplace());
    }

    public void ReplaceObj(GameObject _obj)
    {
        var _replaceFur=_obj.GetComponent<Furnitures_Place>();
        _curPlace = _replaceFur;
        CompeleteUse();

        _fixObject = true;
    }

    #endregion

    #region Btn Replace

    private bool _isRotate = false;
    private float _timeRoate = 0.5f;
    private void RotateLeft()
    {
        _isRotate = true;
        StartCoroutine(Rotate(45));
    }

    private void RotateRight()
    {
        _isRotate = true;
        StartCoroutine(Rotate(-45));
    }

    IEnumerator Rotate(float _angle)
    {
        while(_isRotate)
        {
            _curPlace.Rotate(_angle);
            yield return new WaitForSeconds(_timeRoate);
        }
    }

    private void EndRotate()
    {
        _isRotate = false;
    }

    private void Revert()
    {
        if(_curPlace.IsOldFur())
            _curPlace.RevertPlace();
        else
            Destroy(_curPlace.gameObject);

        PlayerController.instance._playerInteract.SetLayerTarget(GetLayerTarget());
        ClearObjectRepalce();
    }
    #endregion
}
