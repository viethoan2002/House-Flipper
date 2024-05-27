using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MopTool : BaseTool
{
    [SerializeField] private DirtController _curDirt;

    public override void UseTool()
    {
        base.UseTool();
        if (_curDirt == null)
            return;

        _curDirt.SetCleaning(true);
        PopupController.instance._gameplayUI._handleUI._handleLoading.HandleFill(_curDirt.GetFillAmount(), 3);
        MoveUp();
    }

    #region anm Use

    private void MoveUp()
    {
        transform.DOLocalMove(new Vector3(0, 0.14F, 0), .5f).OnComplete(() =>
        {
            _animator.CrossFade("Use", 0.5f);
        });
    }

    private void MoveDown()
    {
        _animator.CrossFade("Idle", 0f);

        transform.DOLocalMove(new Vector3(0, 0, 0), .5f);
    }
    #endregion

    public override void CompeleteUse()
    {
        _curDirt.ClearDirt();
        _curDirt = null;
        MoveDown();
    }

    public override void AddInteractObject(Vector3 _point,GameObject _interactObj,int _index,Vector3 _direction)
    {
        base.AddInteractObject(_point,_interactObj,_index,_direction);

        var _dirt=_interactObj.GetComponent<DirtController>();
        PopupController.instance._gameplayUI._handleUI._handleLoading.SetCanFill(true);

        if(_dirt != null )
        {
            PopupController.instance._gameplayUI._handleUI._handleNotification.SetNoTi("Tap to start cleaning");
        }
        else
        {
            PopupController.instance._gameplayUI._handleUI._handleNotification.CloseNoti();
        }

        if (_dirt == _curDirt)
            return;

        PopupController.instance._gameplayUI._handleUI._handleLoading.SetCanFill(false);
        _curDirt = _dirt;
    }

    public override void ClearObjectInteract()
    {
        base.ClearObjectInteract();
        PopupController.instance._gameplayUI._handleUI._handleLoading.SetCanFill(false);
        PopupController.instance._gameplayUI._handleUI._handleNotification.CloseNoti();

        if (_curDirt != null && _curDirt.GetCleaning())
        {
            _curDirt.SetFillAmount(PopupController.instance._gameplayUI._handleUI._handleLoading.GetFillAmount());
            _curDirt.SetCleaning(false);
            _curDirt = null;
            MoveDown();
        }
    }
}
