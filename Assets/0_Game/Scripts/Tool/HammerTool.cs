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
        if (_isDestroying)
            return;

        if (_curWall.CanDestroy())
        {
            _isDestroying = true;
            _curWall.ActiveOutline(false);

            _animator.CrossFade("Use", 0);
            UIController.Instance._handleUIManager._handleLoading.HandleFill(0, 3);
        }
    }

    public override void AddInteractObject(GameObject _interactObj)
    {
       

        var _newWall=_interactObj.GetComponent<WallController>();

        UIController.Instance._handleUIManager._handleLoading.SetCanFill(true);

        if (_curWall == _newWall)
            return;

        ClearObjectInteract();

        if (_curWall != null && _curWall.CanDestroy())
            base.AddInteractObject(_interactObj);

        UIController.Instance._handleUIManager._handleLoading.SetCanFill(false);
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
    }

    public override void CompeleteUse()
    {
        base.CompeleteUse();

        Destroy(_curWall.gameObject);
        _curWall = null;
        _isDestroying = false;
    }
}
