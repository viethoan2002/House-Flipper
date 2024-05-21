using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCtrl : MonoBehaviour
{
    [SerializeField] private GameObject cellIndicator;
    [SerializeField] private Grid _grid;

    public void UpdateCellPos(Vector3 _lastPos)
    {
        Vector3Int gridPos = _grid.WorldToCell(_lastPos);
        cellIndicator.transform.position = _grid.CellToWorld(gridPos);
    }
}
