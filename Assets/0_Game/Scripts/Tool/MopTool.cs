using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MopTool : BaseTool
{
    [SerializeField] private DirtController _curDirt;

    public override void UseTool()
    {
        if (_curDirt == null)
            return;

        _curDirt.SetCleaning(true);
        UIController.Instance._handleUIManager._handleLoading.HandleFill(_curDirt.GetFillAmount(), 3);
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
        _animator.CrossFade("Idle", 0.5f);

        transform.DOLocalMove(new Vector3(0, 0, 0), .5f);
    }
    #endregion

    public override void CompeleteUse()
    {
        _curDirt.ClearDirt();
        _curDirt = null;
        MoveDown();
    }

    public override void AddInteractObject(GameObject _interactObj)
    {
        base.AddInteractObject(_interactObj);

        var _dirt=_interactObj.GetComponent<DirtController>();
        UIController.Instance._handleUIManager._handleLoading.SetCanFill(true);

        if (_dirt == _curDirt)
            return;

        UIController.Instance._handleUIManager._handleLoading.SetCanFill(false);
        _curDirt = _dirt;
    }

    public override void ClearObjectInteract()
    {
        base.ClearObjectInteract();
        UIController.Instance._handleUIManager._handleLoading.SetCanFill(false);

        if (_curDirt != null && _curDirt.GetCleaning())
        {
            _curDirt.SetFillAmount(UIController.Instance._handleUIManager._handleLoading.GetFillAmount());
            _curDirt.SetCleaning(false);
            _curDirt = null;
            MoveDown();
        }
    }
}
