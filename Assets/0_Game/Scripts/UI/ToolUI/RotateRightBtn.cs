using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RotateRightBtn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static event Action _startRotateRight;
    public static event Action _endRotateRight;

    public void OnPointerDown(PointerEventData eventData)
    {
        _startRotateRight?.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _endRotateRight?.Invoke();
    }
}
