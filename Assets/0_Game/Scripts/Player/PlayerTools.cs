using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTools : MonoBehaviour
{
    [SerializeField] private PlayerController _playerCtrl;
    [SerializeField] private BaseTool _curTool;
    [SerializeField] private List<BaseTool> toolList = new();

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

        _curTool.HideObject();
        _curTool.ClearObjectInteract();

        _curTool = toolList[_index];
        _curTool.ShowObject();
        _playerCtrl._playerInteract.SetLayerTarget(_curTool.GetLayerTarget());
    }

    public void AddObjectInteract(GameObject _obj)
    {
        _curTool.AddInteractObject(_obj);
    }

    public void AddPointRay(Vector3 _point,GameObject _obj)
    {
        _curTool.AddPointRay(_point, _obj);
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
