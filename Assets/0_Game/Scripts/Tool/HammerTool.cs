using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class HammerTool : BaseTool
{
    [SerializeField] private WallController _curWall;

    [SerializeField] private bool _isDestroying;

    public override void UseTool()
    {
        base.UseTool();
        if (_isDestroying)
            return;

        if (_curWall.CanDestroy())
        {
            _isDestroying = true;
            _curWall.ActiveOutline(false);

            _animator.CrossFade("Use", 0);
            PopupController.instance._gameplayUI._handleUI._handleLoading.HandleFill(0, 3);
        }
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

        var _newWall=_interactObj.GetComponent<WallController>();

        PopupController.instance._gameplayUI._handleUI._handleLoading.SetCanFill(true);

        if (_curWall == _newWall)
            return;

        ClearObjectInteract();

        if (_curWall != null && _curWall.CanDestroy())
            base.AddInteractObject(_point,_interactObj,_index,_direction);

        PopupController.instance._gameplayUI._handleUI._handleLoading.SetCanFill(false);
        _curWall = _newWall ;
        _curWall.ActiveOutline(true);
    }

    public override void ClearObjectInteract()
    {
        base.ClearObjectInteract();

        if (_curWall == null)
            return;

        _curWall.ActiveOutline(false);
        _curWall= null ;
        _isDestroying= false;

        _animator.CrossFade("Idle", 0.25f);
        PopupController.instance._gameplayUI._handleUI._handleLoading.SetCanFill(false);
    }

    public override void CompeleteUse()
    {
        base.CompeleteUse();

        Destroy(_curWall.gameObject);
        _curWall = null;
        _isDestroying = false;
        _animator.CrossFade("Idle", 0f);
    }
}
