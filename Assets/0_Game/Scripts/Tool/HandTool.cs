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

            UIController.Instance._handleUIManager._handleLoading.HandleFill(0, 3);
        }
    }

    public override void AddInteractObject(GameObject _interactObj)
    {
        base.AddInteractObject(_interactObj);

        if (_interactObj.layer == LayerMask.NameToLayer("Door"))
        {
            _curDoor = _interactObj.GetComponent<DoorController>();
            if(_curDoor._isOpen)
                UIController.Instance._handleUIManager._handleNotification.SetNoTi("Tap to close");
            else
                UIController.Instance._handleUIManager._handleNotification.SetNoTi("Tap to open");
            return;
        }

        if (_isReplace)
        {
            UIController.Instance._handleUIManager._handleNotification.SetNoTi("Tap to place the item");
            return;
        }

        //base.AddInteractObject(_interactObj);

        var _place = _interactObj.GetComponent<Furnitures_Place>();
        UIController.Instance._handleUIManager._handleLoading.SetCanFill(true);

        if(_place != null)
            UIController.Instance._handleUIManager._handleNotification.SetNoTi("Tap to start moving the item");
        else
            UIController.Instance._handleUIManager._handleNotification.CloseNoti();

        if (_place == _curPlace)
            return;

        UIController.Instance._handleUIManager._handleLoading.SetCanFill(false);
        _curPlace = _place;

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

        UIController.Instance._replaceUIManager.HideUI();
        UIController.Instance._toolUIManager.ShowUI();

        _isReplace = false;
        _curPlace = null;
        _curPoint = Vector3.zero;
        _fixObject = false;

        PlayerController.instance._playerInteract.SetLayerTarget(GetLayerTarget());
    }

    public override void CompeleteUse()
    {
        base.CompeleteUse();

        _isReplace = true;
        _curPlace.SetOrigin();
        _curPlace.SetMaterialGreen();
        _curPlace.EnableCollision(true);

        UIController.Instance._toolUIManager.HideUI();
        UIController.Instance._replaceUIManager.ShowUI();

        PlayerController.instance._playerInteract.SetLayerTarget(_curPlace.GetLayerReplace());
    }

    public void ReplaceObj(GameObject _obj)
    {
        var _replaceFur=_obj.GetComponent<Furnitures_Place>();
        _curPlace = _replaceFur;
        CompeleteUse();

        _fixObject = true;
    }

    public override void AddPointRay(Vector3 _point,GameObject _contruction)
    {
        if(!_isReplace) 
            return;

        base.AddPointRay(_point, _contruction);
        _curPoint = _point;

        if(_curPlace != null)
        {

           _curPlace.Replace(_curPoint,_contruction);
        }
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

        ClearObjectRepalce();
    }
    #endregion
}
