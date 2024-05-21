using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTiles : MonoBehaviour
{
    [SerializeField] private GameObject _outline;
    [SerializeField] private ItemWallFinishes _curTiles;
    [SerializeField] private SpriteRenderer _renderer;

    public void ActiveOutline(bool _active)
    {
        _outline.SetActive(_active);
    }
    
    public bool CheckTiles(ItemWallFinishes _itemTiles)
    {
        return _curTiles == _itemTiles;
    }

    public void SetTiles(ItemWallFinishes _itemIiles)
    {
        _curTiles = _itemIiles;
        _renderer.sprite = _curTiles._texture;
    }
}
