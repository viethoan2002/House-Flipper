using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrowelTool : BaseTool
{
    [SerializeField] private Wall_Slot _curWallSlot;
    [SerializeField] private Wall_Preview _curPreview;
    [SerializeField] private Wall_Preview _upPreview, _downPreview;

    [SerializeField] private GameObject _prefWallUp,_prefWallDown;
    [SerializeField] private Transform _WallManager;

    [SerializeField] private bool _isBuild;
    [SerializeField] private Vector3 _posBuild;
    [SerializeField] private Quaternion _angleBuild;

    public override void AddEventAction()
    {
        base.AddEventAction();
    }

    public override void RemoveEventAction()
    {
        base.RemoveEventAction();
    }

    public override void UseTool()
    {
        base.UseTool();
        if (_isBuild)
            return;

        if(_curWallSlot != null && _curPreview.CanBuild())
        {
            _isBuild = true;
            _curPreview.ActivePreview(false);
           
            _animator.CrossFade("Use", 0);
            _posBuild=_curWallSlot.transform.position;
            _angleBuild = _curWallSlot.transform.rotation;
            PopupController.instance._gameplayUI._handleUI._handleLoading.HandleFill(0, 3);
        }
    }

    public override void AddInteractObject(Vector3 _point, GameObject _interactObj, int _index, Vector3 _direction)
    {
        if (_isBuild)
            return;

        if (_interactObj.layer == LayerMask.NameToLayer("Door"))
        {
            _curDoor = _interactObj.GetComponent<DoorController>();
            if (_curDoor._isOpen)
                PopupController.instance._gameplayUI._handleUI._handleNotification.SetNoTi("Tap to close");
            else
                PopupController.instance._gameplayUI._handleUI._handleNotification.SetNoTi("Tap to open");
            return;
        }

        var _newWallSlot = _interactObj.GetComponent<Wall_Slot>();
        PopupController.instance._gameplayUI._handleUI._handleLoading.SetCanFill(true);

        if (_newWallSlot != _curWallSlot)
        {
            _curWallSlot = _newWallSlot;
            if (_curWallSlot.GetIsFloor())
            {
                _curPreview = _downPreview;
            }
            else
            {
                _curPreview = _upPreview;
            }

            _upPreview.ActivePreview(false);
            _downPreview.ActivePreview(false);

            _curPreview.Preview(_curWallSlot.transform);
        }
        
    }

    public override void CompeleteUse()
    {
        base.CompeleteUse();

        BuildWall();
        _isBuild = false;
    }

    public override void ClearObjectInteract()
    {
        base.ClearObjectInteract();
        if (_isBuild)
            return;

        //base.ClearObjectInteract();

        //_curWallSlot = null;
        //_upPreview.ActivePreview(false);
        //_downPreview.ActivePreview(false);
    }

    #region WALL CONSTRUCTION

    private void BuildWall()
    {
        WallController _newWall = new();
        if(_curPreview == _downPreview)
            _newWall = Instantiate(_prefWallDown, _WallManager).GetComponent<WallController>();
        else
            _newWall = Instantiate(_prefWallUp, _WallManager).GetComponent<WallController>();

        _newWall.Build(_posBuild,_angleBuild);
    }

    #endregion

    public override void ShowObject()
    {
        base.ShowObject();

        _upPreview.gameObject.SetActive(true);
        _downPreview.gameObject.SetActive(true);
        BuildingController.instance.ActivePlacementSystem(true);
    }

    public override void HideObject()
    {
        base.HideObject();
        if(_curPreview != null ) 
            _curPreview.ActivePreview(false);

        _upPreview.ResetPreview();
        _downPreview.ResetPreview();
        BuildingController.instance.ActivePlacementSystem(false);
    }
}
