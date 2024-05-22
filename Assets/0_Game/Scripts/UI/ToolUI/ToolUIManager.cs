using DG.Tweening;
using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolUIManager : BaseUIManager
{
    [SerializeField] private Transform originPos;

    [Space(30)]
    [Header("Button tool")]
    [SerializeField] private List<BaseToolBtn> toolBtns = new List<BaseToolBtn>();

    [SerializeField] private bool _isOpen = false;
    [SerializeField] private float _timeScale = 0.5f;

    public static event Action<int> changeTool;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        //foreach(var btn in toolBtns)
        for(int i = 0; i < toolBtns.Count; i++) 
        {
            var btn = toolBtns[i];
            btn.AddListener(() =>
            {
                changeTool?.Invoke(btn.GetIndexTool());

                _isOpen = !_isOpen;
                if (_isOpen)
                {
                    foreach (var _btn in toolBtns)
                    {
                        _btn.MoveToLocal(_timeScale);
                        _btn.Scale(Vector3.one, _timeScale);
                    }
                }
                else
                {
                    foreach (var _btn in toolBtns)
                    {
                        _btn.MoveToTarget(originPos, _timeScale);

                        if (_btn._targetButton != null)
                        {
                            _btn._targetButton.gameObject.SetActive(true);
                        }

                        if (_btn != btn)
                        {
                            _btn.Scale(Vector3.zero, _timeScale);
                        }

                        if(_btn._targetButton!=null)
                            _btn._targetButton.gameObject.SetActive(false);
                    }
                }         
            });
        }
    }
}
