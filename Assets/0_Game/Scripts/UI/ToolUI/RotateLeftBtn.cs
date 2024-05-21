using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RotateLeftBtn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static event Action _startRotateLeft;
    public static event Action _endRotateLeft;

    public void OnPointerDown(PointerEventData eventData)
    {
        _startRotateLeft?.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _endRotateLeft?.Invoke();
    }
}
