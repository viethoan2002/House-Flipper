using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCtrl : MonoBehaviour
{
    [SerializeField] private GameObject cellIndicator;
    [SerializeField] private Grid _grid;
    [SerializeField] private List<Wall_Slot> _list=new List<Wall_Slot>();

    public void UpdateCellPos(Vector3 _lastPos,bool _isFloor)
    {
        Vector3Int gridPos = _grid.WorldToCell(_lastPos);
        cellIndicator.transform.position = _grid.CellToWorld(gridPos);

        foreach(var _slot in _list)
            _slot.SetIsFloor(_isFloor);
    }
}
