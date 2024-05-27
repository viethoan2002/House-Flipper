using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupProfile : BasePopup
{
    [SerializeField] private Button _btnExit;

    private void Start()
    {
        _btnExit.onClick.AddListener(HidePopupProfile);
    }

    public void HidePopupProfile()
    {
        HideImmediately(false, null);
    }
}