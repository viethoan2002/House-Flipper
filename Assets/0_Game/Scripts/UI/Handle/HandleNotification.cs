using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandleNotification : MonoBehaviour
{
    [SerializeField] private GameObject _notifiTap;

    public void ActiveNotifiTap(bool _active)
    {
        _notifiTap.SetActive(_active);
    }
}
