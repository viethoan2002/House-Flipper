using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TiletrowelTool : BaseTool
{
    [SerializeField] private ItemWallFinishes _curItemTiles;
    [SerializeField] private FloorTiles _curFloorTiles;

    [SerializeField] private bool _isBrick;

    public override void UseTool()
    {
        if (_isBrick || _curFloorTiles == null || _curFloorTiles.CheckTiles(_curItemTiles))
            return;

        UIController.Instance._handleUIManager._handleLoading.HandleFill(0, 0.5f);
        _animator.CrossFade("Use", 0);
        _isBrick = true;
        PlayerController.instance._playerStats.RemoveMoney(_curItemTiles._price);
    }

    public override void AddPointRay(Vector3 _point, GameObject _contruction)
    {
        if (_isBrick)
            return;

        base.AddPointRay(_point, _contruction);
        UIController.Instance._handleUIManager._handleLoading.SetCanFill(true);

        var _newTiles = FloorManager.instance.GetTilesFloor(_point);
        if (_point.y > PlayerController.instance.transform.position.y)
        {
            _newTiles = FloorManager.instance.GetTilesCeiling(_point);
        }

        if (_newTiles == _curFloorTiles)
            return;

        ClearObjectInteract();
        _curFloorTiles = _newTiles;
        _curFloorTiles.ActiveOutline(true);
    }

    public override void CompeleteUse()
    {
        base.CompeleteUse();
        _isBrick = false;
        _curFloorTiles.SetTiles(_curItemTiles);
        _animator.CrossFade("Idle", 0);
    }

    public override void AddItem(BaseItem _item)
    {
        base.AddItem(_item);

        _curItemTiles=(ItemWallFinishes)_item;
    }

    public override void ClearObjectInteract()
    {
        if (_isBrick)
            return;

        base.ClearObjectInteract();

        if(_curFloorTiles != null)
            _curFloorTiles.ActiveOutline(false);
        _curFloorTiles = null;
    }

    public override void HideObject()
    {
        base.HideObject();

        if (_curFloorTiles != null)
            _curFloorTiles.ActiveOutline(false);
        _curFloorTiles = null;
    }
}
