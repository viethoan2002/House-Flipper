using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] public bool _isOpen;
    private bool _isMove;
    
    public void MoveDoor()
    {
        if (_isMove)
            return;

        _isOpen = !_isOpen;

        if (_isOpen)
        {
            _isMove = true;
            transform.DORotate(new Vector3(0, transform.parent.eulerAngles.y - 90, 0), 1f).OnComplete(() =>
            {
                _isMove=false;
            });
        }
        else
        {
            _isMove = true;
            transform.DORotate(new Vector3(0, transform.parent.eulerAngles.y, 0), 1f).OnComplete(() =>
            {
                _isMove = false;
            });
        }
    }
}
