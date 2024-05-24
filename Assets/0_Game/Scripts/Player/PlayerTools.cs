using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerTools : MonoBehaviour
{
    [SerializeField] private PlayerController _playerCtrl;
    [SerializeField] private int _beforIndex,_curIndex;
    [SerializeField] private BaseTool _curTool;
    [SerializeField] private List<BaseTool> toolList = new();
    [SerializeField] private BaseItem _curItem;

    private void Awake()
    {
        LoadComponent();
    }

    private void OnEnable()
    {
        ToolUIManager.changeTool += ChangeTool;
    }

    private void OnDisable()
    {
        ToolUIManager.changeTool -= ChangeTool;
    }

    private void Start()
    {
        SetUpTool();      
    }

    private void LoadComponent()
    {
        _playerCtrl = GetComponent<PlayerController>();
    }

    private void SetUpTool()
    {
        _curTool = toolList[0];
        _playerCtrl._playerInteract.SetLayerTarget(_curTool.GetLayerTarget());

        for (int i = 1; i < toolList.Count; i++)
        {
            toolList[i].SetUpPosition();
        }
    }

    private void ChangeTool(int _index)
    {
        if (_curTool == toolList[_index])
            return;

        _beforIndex = _curIndex;
        _curIndex = _index;

        _curTool.HideObject();
        _curTool.ClearObjectInteract();

        _curTool = toolList[_index];
        _curTool.ShowObject();
        _playerCtrl._playerInteract.SetLayerTarget(_curTool.GetLayerTarget());

        UIController.Instance._handleUIManager._handleNotification.CloseNoti();
        UIController.Instance._handleUIManager._handleNotification.CloseWaring();
    }

    public void ChangeOldTool()
    {
        ChangeTool(_beforIndex);
    }

    public void AddObjectInteract(GameObject _obj)
    {
        _curTool.AddInteractObject(_obj);
    }

    public void AddPointRay(Vector3 _point,GameObject _obj)
    {
        _curTool.AddPointRay(_point, _obj);
    }

    public void AddTriangleIndex(int _index, GameObject _interactObj)
    {
        _curTool.AddTriangleIndex(_index,_interactObj);
    }

    public void AddBaseItem(BaseItem _item)
    {
        if(_item is ItemWallFinishes)
        {
            ItemWallFinishes _tiles = (ItemWallFinishes)_item;

            if (_tiles._type == WallFinishes.Tiles)
            {
                ChangeTool(4);
                _curTool.AddItem(_item);
            }
            else
            {
                ChangeTool(0);
                
                _playerCtrl._playerStats.RemoveMoney(_item._price);
                HandTool _handTool=(HandTool)_curTool;
                _handTool.ReplaceObj(Instantiate(_tiles._prefObj));
            }

        }
        else
        {
            ChangeTool(0);

            HandTool _handTool = (HandTool)_curTool;
            _handTool.ReplaceObj(Instantiate(_item._prefObj));
        }
    }

    public void ClearObjectInteract()
    {
        _curTool.ClearObjectInteract();
    }

    private void Reset()
    {
        LoadComponent();
    }
}
