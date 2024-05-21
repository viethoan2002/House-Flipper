using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    public static FloorManager instance;
    [SerializeField] private List<FloorTiles> _tilesFloor = new List<FloorTiles>();
    [SerializeField] private List<FloorTiles> _tilesCeiling=new List<FloorTiles>();

    private FloorTiles _curTiles;

    private void Awake()
    {
        if(FloorManager.instance ==null)
            FloorManager.instance = this;
    }

    public FloorTiles GetTilesFloor(Vector3 _pos)
    {
        float _distance=float.MaxValue;
        _curTiles = _tilesFloor[0];
        for(int i = 0; i < _tilesFloor.Count; i++)
        {
            if (Vector3.Distance(_pos, _tilesFloor[i].transform.position) < _distance)
            {
                _curTiles = _tilesFloor[i];
                _distance = Vector3.Distance(_pos, _tilesFloor[i].transform.position);
            }
        }

        return _curTiles;
    }

    public FloorTiles GetTilesCeiling(Vector3 _pos)
    {
        float _distance = float.MaxValue;
        _curTiles = _tilesCeiling[0];
        for (int i = 0; i < _tilesCeiling.Count; i++)
        {
            if (Vector3.Distance(_pos, _tilesCeiling[i].transform.position) < _distance)
            {
                _curTiles = _tilesCeiling[i];
                _distance = Vector3.Distance(_pos, _tilesCeiling[i].transform.position);
            }
        }

        return _curTiles;
    }
}
