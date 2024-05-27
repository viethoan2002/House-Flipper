using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupPause : BasePopup
{
    [SerializeField] private Button _btnExit;

    private void Awake()
    {
        _btnExit.onClick.AddListener(HidePause);
    }

    private void HidePause()
    {
        HideImmediately(false, null);
    }
}
