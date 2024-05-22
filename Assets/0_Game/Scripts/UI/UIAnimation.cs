using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimation : MonoBehaviour
{
    [SerializeField] private Transform _targetPos;
    [SerializeField] private Transform _originPos;

    [SerializeField] private float _timeDuration;

    public void MoveToOrigin()
    {
        transform.position = _targetPos.position;
        transform.DOMove(_originPos.position, _timeDuration);
    }

    public void MoveToTarget()
    {
        transform.position = _originPos.position;
        transform.DOMove(_targetPos.position, _timeDuration);
    }
}
