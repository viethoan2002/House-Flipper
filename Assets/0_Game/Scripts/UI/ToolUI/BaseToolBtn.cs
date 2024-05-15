using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseToolBtn : MonoBehaviour
{
    [SerializeField] private Vector3 _localPos;
    [SerializeField] private Button _button;
    [SerializeField] private int _indexTool;

    private void Awake()
    {
        LoadComponent();
    }

    private void LoadComponent()
    {
        _button = GetComponent<Button>();
    }

    public void AddListener(Action _action)
    {
        _button.onClick.AddListener(() =>
        {
            _action?.Invoke();

        });
    }

    public void MoveToTarget(Transform target,float _time)
    {
        transform.DOLocalMove(target.localPosition, _time);
    }

    public void MoveToLocal(float _time)
    {
        transform.DOLocalMove(_localPos, _time);
    }

    public void Scale(Vector3 _scale,float _time)
    {
        transform.DOScale(_scale, _time);
    }

    public int GetIndexTool()
    {
        return _indexTool;
    }

    private void Reset()
    {
        LoadComponent();
    }
}
